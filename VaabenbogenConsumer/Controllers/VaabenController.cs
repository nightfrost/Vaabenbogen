using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaabenbogenConsumer.Data;
using VaabenbogenConsumer.Models;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vaaben.ToListAsync());
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

        // GET: Vaaben/Create
        public IActionResult Create()
        {
            ViewBag.LadefunktionOptions = Enum.GetValues(typeof(Ladefunktion)).Cast<Ladefunktion>();
            ViewBag.TypeOptions = Enum.GetValues(typeof(VaabenType)).Cast<VaabenType>();
            ViewBag.StatusOptions = Enum.GetValues(typeof(VaabenStatus)).Cast<VaabenStatus>();
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

            var vaaben = await _context.Vaaben.FindAsync(id);
            if (vaaben == null)
            {
                return NotFound();
            }
            return View(vaaben);
        }

        // GET: Vaaben/Search/Query
        public async Task<IActionResult> Search([Bind("Id,Navn,Fabrikant,Ladefunktion,Loebenummer,Type,Status")] SoegVaaben soegVaaben)
        {
            if (string.IsNullOrWhiteSpace(soegVaaben.Navn) 
                && string.IsNullOrWhiteSpace(soegVaaben.Fabrikant) 
                && soegVaaben.Status == null
                && soegVaaben.Ladefunktion == null
                && string.IsNullOrWhiteSpace(soegVaaben.Loebenummer)
                && soegVaaben.Type == null)
            {
                return NotFound();
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
                query = query.Where(v => v.Type== soegVaaben.Type.Value);
            }

            var queryResult = await query.ToListAsync();

            if (queryResult == null || !query.Any())
            {
                return NotFound();
            }
            return View(queryResult);
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
