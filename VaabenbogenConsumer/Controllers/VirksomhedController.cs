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
    public class VirksomhedController : Controller
    {
        private readonly VaabenBogenContext _context;

        public VirksomhedController(VaabenBogenContext context)
        {
            _context = context;
        }

        // GET: Virksomhed
        public async Task<IActionResult> Index()
        {
            return View(await _context.Virksomheder.ToListAsync());
        }

        // GET: Virksomhed/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.Virksomheder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (virksomhed == null)
            {
                return NotFound();
            }

            return View(virksomhed);
        }

        // GET: Virksomhed/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Virksomhed/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cvr,Navn,Adresse,Zip,By,StartDato,EndDato,Id,Telefon,Email,Mobil,JaegerId,Created,CreatedBy,Updated,UpdatedBy")] Virksomhed virksomhed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(virksomhed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(virksomhed);
        }

        // GET: Virksomhed/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.Virksomheder.FindAsync(id);
            if (virksomhed == null)
            {
                return NotFound();
            }
            return View(virksomhed);
        }

        // POST: Virksomhed/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cvr,Navn,Adresse,Zip,By,StartDato,EndDato,Id,Telefon,Email,Mobil,JaegerId,Created,CreatedBy,Updated,UpdatedBy")] Virksomhed virksomhed)
        {
            if (id != virksomhed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(virksomhed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VirksomhedExists(virksomhed.Id))
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
            return View(virksomhed);
        }

        // GET: Virksomhed/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.Virksomheder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (virksomhed == null)
            {
                return NotFound();
            }

            return View(virksomhed);
        }

        // POST: Virksomhed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var virksomhed = await _context.Virksomheder.FindAsync(id);
            if (virksomhed != null)
            {
                _context.Virksomheder.Remove(virksomhed);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VirksomhedExists(int id)
        {
            return _context.Virksomheder.Any(e => e.Id == id);
        }
    }
}
