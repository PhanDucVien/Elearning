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
    public class TakeClassesController : Controller
    {
        private readonly ElearningContext _context;

        public TakeClassesController(ElearningContext context)
        {
            _context = context;
        }

        // GET: TakeClasses
        public async Task<IActionResult> Index()
        {
              return _context.TakeClass != null ? 
                          View(await _context.TakeClass.ToListAsync()) :
                          Problem("Entity set 'ElearningContext.TakeClass'  is null.");
        }

        // GET: TakeClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TakeClass == null)
            {
                return NotFound();
            }

            var takeClass = await _context.TakeClass
                .FirstOrDefaultAsync(m => m.TakeClassId == id);
            if (takeClass == null)
            {
                return NotFound();
            }

            return View(takeClass);
        }

        // GET: TakeClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TakeClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TakeClassId,Topic,Description,Workingtime,Startdate,Enddate,Security,Link")] TakeClass takeClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(takeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(takeClass);
        }

        // GET: TakeClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TakeClass == null)
            {
                return NotFound();
            }

            var takeClass = await _context.TakeClass.FindAsync(id);
            if (takeClass == null)
            {
                return NotFound();
            }
            return View(takeClass);
        }

        // POST: TakeClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TakeClassId,Topic,Description,Workingtime,Startdate,Enddate,Security,Link")] TakeClass takeClass)
        {
            if (id != takeClass.TakeClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(takeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TakeClassExists(takeClass.TakeClassId))
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
            return View(takeClass);
        }

        // GET: TakeClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TakeClass == null)
            {
                return NotFound();
            }

            var takeClass = await _context.TakeClass
                .FirstOrDefaultAsync(m => m.TakeClassId == id);
            if (takeClass == null)
            {
                return NotFound();
            }

            return View(takeClass);
        }

        // POST: TakeClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TakeClass == null)
            {
                return Problem("Entity set 'ElearningContext.TakeClass'  is null.");
            }
            var takeClass = await _context.TakeClass.FindAsync(id);
            if (takeClass != null)
            {
                _context.TakeClass.Remove(takeClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TakeClassExists(int id)
        {
          return (_context.TakeClass?.Any(e => e.TakeClassId == id)).GetValueOrDefault();
        }
    }
}
