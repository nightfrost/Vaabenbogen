using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VaabenbogenConsumer.Data;
using VaabenbogenConsumer.Helpers;
using VaabenbogenConsumer.Models;
using VaabenbogenConsumer.Models.ViewModels;

namespace VaabenbogenConsumer.Controllers
{
    [Authorize]
    public class VaabenController : Controller
    {
        private readonly VaabenBogenContext _context;
        private readonly ILogger<VaabenController> _logger;

        public VaabenController(VaabenBogenContext context, ILogger<VaabenController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Vaaben
        public async Task<IActionResult> Index(SoegVaaben? search)
        {
            if (search == null) search = new SoegVaaben();
            ViewBag.SoegVaabenObject = search;

            ViewBag.StatusOptions = DropdownHelper.VaabenStatusDropdownOptions();
            ViewBag.LadefunktionOptions = DropdownHelper.LadefunktionDropdownOptions();
            ViewBag.TypeOptions = DropdownHelper.VaabenTypeDropdownOptions();


            return View(viewName:"Index", await SearchWeapons(search));
        }

        public async Task<IActionResult> ResetSearch()
        {
            return await Index(null);
        }

        private async Task<List<Vaaben>> SearchWeapons(SoegVaaben soegVaaben)
        {
            if (string.IsNullOrWhiteSpace(soegVaaben.Navn)
                && string.IsNullOrWhiteSpace(soegVaaben.Fabrikant)
                && soegVaaben.Status == null
                && soegVaaben.Ladefunktion == null
                && string.IsNullOrWhiteSpace(soegVaaben.Loebenummer)
                && soegVaaben.Type == null)
            {
                return await _context.Vaaben.ToListAsync();
            }
            var query = _context.Vaaben.AsQueryable();

            if (!string.IsNullOrWhiteSpace(soegVaaben.Navn))
            {
                query = query.Where(v => v.Navn.Contains(soegVaaben.Navn));
            }

            if (!string.IsNullOrWhiteSpace(soegVaaben.Fabrikant))
            {
                query = query.Where(v => v.Fabrikant == soegVaaben.Fabrikant);
            }

            if (soegVaaben.Status.HasValue)
            {
                query = query.Where(v => v.Status == soegVaaben.Status.Value);
            }

            if (soegVaaben.Ladefunktion.HasValue)
            {
                query = query.Where(v => v.Ladefunktion == soegVaaben.Ladefunktion.Value);
            }

            if (!string.IsNullOrWhiteSpace(soegVaaben.Loebenummer))
            {
                query = query.Where(v => v.Loebenummer == soegVaaben.Loebenummer);
            }

            if (soegVaaben.Type.HasValue)
            {
                query = query.Where(v => v.Type == soegVaaben.Type.Value);
            }

            return await query.ToListAsync();
        }

        // GET: Vaaben/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaaben = await _context.Vaaben
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaaben == null)
            {
                return NotFound();
            }

            return View(vaaben);
        }

        // GET: Vaaben/Release/5
        public async Task<IActionResult> Release(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaaben = await _context.Vaaben
                .FirstOrDefaultAsync(m => m.Id == id);

            var releasedToOptions = await _context.Virksomheder
                .Select(virks => new SelectListItem
                {
                    Text = virks.Navn,
                    Value = virks.Cvr
                }).ToListAsync();

            releasedToOptions.AddRange(await _context.Jaegere
                .Select(jaegers => new SelectListItem
                { 
                    Text = jaegers.Fornavn, 
                    Value = jaegers.Cpr
                }).ToListAsync());

            ViewBag.ReleasedToOptions = releasedToOptions;

            if (releasedToOptions.IsNullOrEmpty())
            {
                ViewBag.ReleasedToOptions = null;
            }

            return View(vaaben);
        }

        // POST: Vaaben/Release/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Release(Vaaben vaaben, ReleaseVaabenViewModel? model, string? releasedTo)
        {
            if ((model == null && string.IsNullOrWhiteSpace(releasedTo)) || vaaben == null || vaaben.Id == 0) return await Index(null);

            //New Customer case.
            bool udskrivelseSuccess = false;
            if (string.IsNullOrWhiteSpace(releasedTo) && model != null &&(!string.IsNullOrWhiteSpace(model.newJaegerId) || !string.IsNullOrWhiteSpace(model.newCompanyJaegerId)))
            {
                if (model.isCompany is true) //Company
                {
                    Virksomhed newVirksomhed = new()
                    {
                        Cvr = model.newCvr ?? throw new ArgumentNullException(model.newCvr),
                        Navn = model.newCompanyName ?? throw new ArgumentNullException(model.newCompanyName),
                        JaegerId = model.newCompanyJaegerId ?? throw new ArgumentNullException(model.newCompanyJaegerId),
                        Email = model.newCompanyEmail ?? throw new ArgumentNullException(model.newCompanyEmail),
                        Telefon = model.newCompanyPhone ?? throw new ArgumentNullException(model.newCompanyPhone),
                        Mobil = model.newCompanyPhone ?? throw new ArgumentNullException(model.newCompanyPhone)
                    };

                    _context.Virksomheder.Add(newVirksomhed);
                    var result = await _context.SaveChangesAsync();
                    if (result != 1)
                    {
                        DbUpdateException exception = new(message: $"Failed to add new Virksomhed with JaegerId: {model.newCompanyJaegerId}");
                        _logger.LogCritical($"Failed to add new Virksomhed with JaegerId: {model.newCompanyJaegerId}", exception);
                        throw exception;
                    }

                    var dbVirksomhed = await _context.Virksomheder.Where(virk => virk.JaegerId == newVirksomhed.JaegerId).FirstOrDefaultAsync();

                    Udskrivelser udskrivelser = new()
                    {
                        CreatedBy = HttpContext.User.Identity?.Name ?? "System",
                        UdskrevetTilVirksomhed = dbVirksomhed
                    };

                    _context.Udskrivelser.Add(udskrivelser);
                    result = await _context.SaveChangesAsync();

                    if (result != 1)
                    {
                        DbUpdateException exception = new(message: $"Failed to save Udskrivelse at {udskrivelser.Created}");
                        _logger.LogCritical($"Failed to save Udskrivelse at {udskrivelser.Created}", exception);
                        throw exception;
                    }
                    udskrivelseSuccess = true;
                } else //Jaeger
                {
                    Jaeger newJaeger = new()
                    {
                        Fornavn = model.newFirstName ?? throw new ArgumentNullException(model.newFirstName),
                        Efternavn = model.newLastName ?? throw new ArgumentNullException(model.newLastName),
                        Email = model.newEmail ?? throw new ArgumentNullException(model.newEmail),
                        JaegerId = model.newJaegerId ?? throw new ArgumentNullException(model.newJaegerId),
                        Telefon = model.newPhone ?? throw new ArgumentNullException(model.newPhone),
                    };

                    int result = 0;

                    try
                    {
                        _context.Jaegere.Add(newJaeger);
                        result = await _context.SaveChangesAsync();
                        if (result != 1)
                        {
                            DbUpdateException exception = new(message: $"Failed to add new Jaeger with JaegerId: {model.newJaegerId}");
                            _logger.LogCritical($"Failed to add new Jaeger with JaegerId: {model.newJaegerId}", exception);
                            throw exception;
                        }
                    }
                    catch (DbUpdateException)
                    {
                        //TODO: Handle
                        throw;
                    }
                    catch (Exception)
                    {
                        //TODO: Handle
                        throw;
                    }

                    var dbJaeger = await _context.Jaegere.Where(jaeger => jaeger.JaegerId == model.newJaegerId).FirstOrDefaultAsync();

                    Udskrivelser udskrivelser = new()
                    {
                        CreatedBy = HttpContext.User.Identity?.Name ?? "System",
                        UdskrevetTilJaeger = dbJaeger
                    };

                    try
                    {
                        _context.Udskrivelser.Add(udskrivelser);
                        result = await _context.SaveChangesAsync();
                        if (result != 1)
                        {
                            DbUpdateException exception = new(message: $"Failed to save Udskrivelse at {udskrivelser.Created}");
                            _logger.LogCritical($"Failed to save Udskrivelse at {udskrivelser.Created}", exception);
                            throw exception;
                        }
                    }
                    catch (DbUpdateException)
                    {
                        //TODO: Handle
                        throw;
                    }
                    catch (Exception)
                    {
                        //TODO: Handle
                        throw;
                    }
                    
                    udskrivelseSuccess = true;
                }
            } else
            {//Existing Customer case.
                Udskrivelser udskrivelser = new() { CreatedBy = HttpContext.User.Identity?.Name ?? "System" };

                var jaegerResult = await _context.Jaegere.FirstOrDefaultAsync(jaeger => jaeger.Cpr == releasedTo);

                //Jaeger case
                if (jaegerResult != null)
                {
                    udskrivelser.UdskrevetTilJaeger = jaegerResult;
                } else
                {//Company case
                    var virksomhedResult = await _context.Virksomheder.FirstOrDefaultAsync(virk => virk.Cvr == releasedTo);
                    udskrivelser.UdskrevetTilVirksomhed = virksomhedResult;
                }

                try
                {
                    _context.Udskrivelser.Add(udskrivelser);
                    var result = await _context.SaveChangesAsync();
                    if (result != 1)
                    {
                        DbUpdateException exception = new(message: $"Failed to save Udskrivelse at {udskrivelser.Created}");
                        _logger.LogCritical($"Failed to save Udskrivelse at {udskrivelser.Created}", exception);
                        throw exception;
                    }
                }
                catch (DbUpdateException)
                {
                    //TODO: Handle
                    throw;
                }
                catch (Exception)
                {
                    //TODO: Handle
                    throw;
                }

                udskrivelseSuccess = true;
            }

            if (udskrivelseSuccess)
            {
                await _context.Vaaben
                    .Where(dbVaaben => dbVaaben.Id == vaaben.Id)
                    .ExecuteUpdateAsync(setters =>
                        setters.SetProperty(v => v.IsUdskrevet, true));
            }

            return await Index(null);
        }

        // GET: Vaaben/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.StatusOptions = DropdownHelper.VaabenStatusDropdownOptions();
            ViewBag.LadefunktionOptions = DropdownHelper.LadefunktionDropdownOptions();
            ViewBag.TypeOptions = DropdownHelper.VaabenTypeDropdownOptions();
            ViewBag.IndskriverOptions = await DropdownHelper.IndskriverDropdownOptions(_context);
            return View();
        }

        // POST: Vaaben/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Navn,Fabrikant,Ladefunktion,Loebenummer,Type,Status,Indskriver")] Vaaben vaaben)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaaben);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaaben);
        }

        // GET: Vaaben/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.StatusOptions = DropdownHelper.VaabenStatusDropdownOptions();
            ViewBag.LadefunktionOptions = DropdownHelper.LadefunktionDropdownOptions();
            ViewBag.TypeOptions = DropdownHelper.VaabenTypeDropdownOptions();

            var vaaben = await _context.Vaaben.FindAsync(id);
            if (vaaben == null)
            {
                return NotFound();
            }
            return View(vaaben);
        }

        // POST: Vaaben/Search/Query
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(SoegVaaben soegVaaben)
        {
            if (string.IsNullOrWhiteSpace(soegVaaben.Navn)
                && string.IsNullOrWhiteSpace(soegVaaben.Fabrikant)
                && soegVaaben.Status == null
                && soegVaaben.Ladefunktion == null
                && string.IsNullOrWhiteSpace(soegVaaben.Loebenummer)
                && soegVaaben.Type == null)
            {
                return View(viewName: "Index", soegVaaben);
            }
            var query = _context.Vaaben.AsQueryable();

            if (!string.IsNullOrWhiteSpace(soegVaaben.Navn))
            {
                query = query.Where(v => v.Navn.Contains(soegVaaben.Navn));
            }

            if (!string.IsNullOrWhiteSpace(soegVaaben.Fabrikant))
            {
                query = query.Where(v => v.Fabrikant == soegVaaben.Fabrikant);
            }

            if (soegVaaben.Status.HasValue)
            {
                query = query.Where(v => v.Status == soegVaaben.Status.Value);
            }

            if (soegVaaben.Ladefunktion.HasValue)
            {
                query = query.Where(v => v.Ladefunktion == soegVaaben.Ladefunktion.Value);
            }

            if (!string.IsNullOrWhiteSpace(soegVaaben.Loebenummer))
            {
                query = query.Where(v => v.Loebenummer == soegVaaben.Loebenummer);
            }

            if (soegVaaben.Type.HasValue)
            {
                query = query.Where(v => v.Type == soegVaaben.Type.Value);
            }

            var queryResult = await query.ToListAsync();

            if (queryResult == null || !query.Any())
            {
                return View(viewName: "Index", queryResult);
            }
            return View(viewName: "Index", model: queryResult);
        }

        // POST: Vaaben/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Navn,Fabrikant,Ladefunktion,Loebenummer,Type,Status")] Vaaben vaaben)
        {
            if (id != vaaben.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaaben);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaabenExists(vaaben.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vaaben);
        }

        // GET: Vaaben/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaaben = await _context.Vaaben
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaaben == null)
            {
                return NotFound();
            }

            return View(vaaben);
        }

        // POST: Vaaben/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaaben = await _context.Vaaben.FindAsync(id);
            if (vaaben != null)
            {
                _context.Vaaben.Remove(vaaben);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaabenExists(int id)
        {
            return _context.Vaaben.Any(e => e.Id == id);
        }
    }
}
