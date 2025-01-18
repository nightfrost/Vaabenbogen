using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaabenbogenConsumer.Data;
using VaabenbogenConsumer.Helpers;
using VaabenbogenConsumer.Models;
using VaabenbogenConsumer.Models.ViewModels;

namespace VaabenbogenConsumer.Controllers
{
    public class VaabenController : Controller
    {
        private readonly VaabenBogenContext _context;

        public VaabenController(VaabenBogenContext context)
        {
            _context = context;
        }

        // GET: Vaaben
        public async Task<IActionResult> Index(SoegVaaben? search)
        {
            if (search == null) search = new SoegVaaben();
            ViewBag.SoegVaabenObject = search;

            ViewBag.StatusOptions = DropdownHelper.VaabenStatusDropdownOptions();
            ViewBag.LadefunktionOptions = DropdownHelper.LadefunktionDropdownOptions();
            ViewBag.TypeOptions = DropdownHelper.VaabenTypeDropdownOptions();


            return View(await SearchWeapons(search));
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

        // GET: Vaaben/Details/5
        public async Task<IActionResult> Release(int? id)
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

        // GET: Vaaben/Create
        public IActionResult Create()
        {
            ViewBag.StatusOptions = DropdownHelper.VaabenStatusDropdownOptions();
            ViewBag.LadefunktionOptions = DropdownHelper.LadefunktionDropdownOptions();
            ViewBag.TypeOptions = DropdownHelper.VaabenTypeDropdownOptions();
            return View();
        }

        // POST: Vaaben/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Navn,Fabrikant,Ladefunktion,Loebenummer,Type,Status")] Vaaben vaaben)
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
