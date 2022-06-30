using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Elearning.Data;
using Elearning.Models;
using Elearning.Services;

namespace Elearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private IFormat _format;
        public FormatsController(IFormat format)
        {
            _format = format;

        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult getFormats()
        {
            return Ok(_format.GetFormats());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult getFormat(int id)
        {
            var format = _format.GetFormat(id);
            if(format != null)
            {
                return Ok(format);
            }
            return NotFound("loi");
        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetFormat(Format format)
        {
            _format.AddFormat(format);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + format.FormatId, format);

        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteFormat(int id)
        {
            var format = _format.GetFormat(id);
            if(format != null)
            {
                _format.DeteleFormat(format);
            }
            return NotFound("loi");
        }
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditFormat(int id, Format format)
        {
            var existingFormat = _format.GetFormat(id);
            if(existingFormat != null)
            {
                format.FormatId = existingFormat.FormatId;
                _format.EditFormat(format);
            }
            return Ok(format);
        }
        //private readonly ElearningContext _context;

        //public FormatsController(ElearningContext context)
        //{
        //    _context = context;

        //}

        //// GET: api/Formats
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Format>>> GetFormat()
        //{
        //  if (_context.Format == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Format.ToListAsync();
        //}

        //// GET: api/Formats/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Format>> GetFormat(int id)
        //{
        //  if (_context.Format == null)
        //  {
        //      return NotFound();
        //  }
        //    var format = await _context.Format.FindAsync(id);

        //    if (format == null)
        //    {
        //        return NotFound();
        //    }

        //    return format;
        //}

        //// PUT: api/Formats/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFormat(int id, Format format)
        //{
        //    if (id != format.FormatId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(format).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FormatExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Formats
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Format>> PostFormat(Format format)
        //{
        //  if (_context.Format == null)
        //  {
        //      return Problem("Entity set 'ElearningContext.Format'  is null.");
        //  }
        //    _context.Format.Add(format);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFormat", new { id = format.FormatId }, format);
        //}

        //// DELETE: api/Formats/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFormat(int id)
        //{
        //    if (_context.Format == null)
        //    {
        //        return NotFound();
        //    }
        //    var format = await _context.Format.FindAsync(id);
        //    if (format == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Format.Remove(format);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool FormatExists(int id)
        //{
        //    return (_context.Format?.Any(e => e.FormatId == id)).GetValueOrDefault();
        //}
    }
}
