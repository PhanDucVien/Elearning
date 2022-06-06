using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Elearning.Data;
using Elearning.Models;

namespace Elearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeClassesController : ControllerBase
    {
        private readonly ElearningContext _context;

        public TakeClassesController(ElearningContext context)
        {
            _context = context;
        }

        // GET: api/TakeClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TakeClass>>> GetTakeClass()
        {
          if (_context.TakeClass == null)
          {
              return NotFound();
          }
            return await _context.TakeClass.ToListAsync();
        }

        // GET: api/TakeClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TakeClass>> GetTakeClass(int id)
        {
          if (_context.TakeClass == null)
          {
              return NotFound();
          }
            var takeClass = await _context.TakeClass.FindAsync(id);

            if (takeClass == null)
            {
                return NotFound();
            }

            return takeClass;
        }

        // PUT: api/TakeClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeClass(int id, TakeClass takeClass)
        {
            if (id != takeClass.TakeClassId)
            {
                return BadRequest();
            }

            _context.Entry(takeClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakeClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TakeClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TakeClass>> PostTakeClass(TakeClass takeClass)
        {
          if (_context.TakeClass == null)
          {
              return Problem("Entity set 'ElearningContext.TakeClass'  is null.");
          }
            _context.TakeClass.Add(takeClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakeClass", new { id = takeClass.TakeClassId }, takeClass);
        }

        // DELETE: api/TakeClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTakeClass(int id)
        {
            if (_context.TakeClass == null)
            {
                return NotFound();
            }
            var takeClass = await _context.TakeClass.FindAsync(id);
            if (takeClass == null)
            {
                return NotFound();
            }

            _context.TakeClass.Remove(takeClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TakeClassExists(int id)
        {
            return (_context.TakeClass?.Any(e => e.TakeClassId == id)).GetValueOrDefault();
        }
    }
}
