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
    public class MyclassesController : ControllerBase
    {
        private readonly ElearningContext _context;

        public MyclassesController(ElearningContext context)
        {
            _context = context;
        }

        // GET: api/Myclasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Myclass>>> GetMyclass()
        {
          if (_context.Myclass == null)
          {
              return NotFound();
          }
            return await _context.Myclass.ToListAsync();
        }

        // GET: api/Myclasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Myclass>> GetMyclass(int id)
        {
          if (_context.Myclass == null)
          {
              return NotFound();
          }
            var myclass = await _context.Myclass.FindAsync(id);

            if (myclass == null)
            {
                return NotFound();
            }

            return myclass;
        }

        // PUT: api/Myclasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyclass(int id, Myclass myclass)
        {
            if (id != myclass.MyclassId)
            {
                return BadRequest();
            }

            _context.Entry(myclass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyclassExists(id))
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

        // POST: api/Myclasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Myclass>> PostMyclass(Myclass myclass)
        {
          if (_context.Myclass == null)
          {
              return Problem("Entity set 'ElearningContext.Myclass'  is null.");
          }
            _context.Myclass.Add(myclass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyclass", new { id = myclass.MyclassId }, myclass);
        }

        // DELETE: api/Myclasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyclass(int id)
        {
            if (_context.Myclass == null)
            {
                return NotFound();
            }
            var myclass = await _context.Myclass.FindAsync(id);
            if (myclass == null)
            {
                return NotFound();
            }

            _context.Myclass.Remove(myclass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyclassExists(int id)
        {
            return (_context.Myclass?.Any(e => e.MyclassId == id)).GetValueOrDefault();
        }
    }
}
