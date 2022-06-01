using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Elearning.Data;
using Elearning.Models;

namespace Elearning.Controllers
{
    public class MyclassController : Controller
    {
        private readonly ElearningContext _context;

        public MyclassController(ElearningContext context)
        {
            _context = context;
        }

        // GET: Myclass
        public async Task<IActionResult> Index()
        {
              return _context.Myclass != null ? 
                          View(await _context.Myclass.ToListAsync()) :
                          Problem("Entity set 'ElearningContext.Myclass'  is null.");
        }

        // GET: Myclass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Myclass == null)
            {
                return NotFound();
            }

            var myclass = await _context.Myclass
                .FirstOrDefaultAsync(m => m.MyclassId == id);
            if (myclass == null)
            {
                return NotFound();
            }

            return View(myclass);
        }

        // GET: Myclass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Myclass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyclassId,Name")] Myclass myclass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myclass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myclass);
        }

        // GET: Myclass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Myclass == null)
            {
                return NotFound();
            }

            var myclass = await _context.Myclass.FindAsync(id);
            if (myclass == null)
            {
                return NotFound();
            }
            return View(myclass);
        }

        // POST: Myclass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyclassId,Name")] Myclass myclass)
        {
            if (id != myclass.MyclassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myclass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyclassExists(myclass.MyclassId))
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
            return View(myclass);
        }

        // GET: Myclass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Myclass == null)
            {
                return NotFound();
            }

            var myclass = await _context.Myclass
                .FirstOrDefaultAsync(m => m.MyclassId == id);
            if (myclass == null)
            {
                return NotFound();
            }

            return View(myclass);
        }

        // POST: Myclass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Myclass == null)
            {
                return Problem("Entity set 'ElearningContext.Myclass'  is null.");
            }
            var myclass = await _context.Myclass.FindAsync(id);
            if (myclass != null)
            {
                _context.Myclass.Remove(myclass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyclassExists(int id)
        {
          return (_context.Myclass?.Any(e => e.MyclassId == id)).GetValueOrDefault();
        }
    }
}
