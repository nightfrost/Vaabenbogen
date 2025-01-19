using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VaabenbogenConsumer.Data;
using VaabenbogenConsumer.Models;
using VaabenbogenConsumer.Models.ViewModels;

namespace VaabenbogenConsumer.Controllers
{
    public class JaegerController : Controller
    {
        private readonly VaabenBogenContext _context;

        public JaegerController(VaabenBogenContext context)
        {
            _context = context;
        }

        // GET: Jaeger
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jaegere.ToListAsync());
        }

        // GET: Jaeger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jaeger = await _context.Jaegere
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jaeger == null)
            {
                return NotFound();
            }

            return View(jaeger);
        }

        // GET: Jaeger/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jaeger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fornavn,Efternavn,Cpr,Id,Telefon,Email,Mobil,JaegerId")] Jaeger jaeger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jaeger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jaeger);
        }

        // GET: Jaeger/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jaeger = await _context.Jaegere.FindAsync(id);
            if (jaeger == null)
            {
                return NotFound();
            }
            return View(jaeger);
        }

        // POST: Jaeger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fornavn,Efternavn,Cpr,Foedselsdato,Id,Telefon,Email,Mobil,JaegerId,Created,CreatedBy,Updated,UpdatedBy")] Jaeger jaeger)
        {
            if (id != jaeger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jaeger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JaegerExists(jaeger.Id))
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
            return View(jaeger);
        }

        // GET: Jaeger/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jaeger = await _context.Jaegere
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jaeger == null)
            {
                return NotFound();
            }

            return View(jaeger);
        }

        // POST: Jaeger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jaeger = await _context.Jaegere.FindAsync(id);
            if (jaeger != null)
            {
                _context.Jaegere.Remove(jaeger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JaegerExists(int id)
        {
            return _context.Jaegere.Any(e => e.Id == id);
        }
    }
}
