using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_CSharp;
using api_CSharp.Models;

namespace api_CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddFolks1Controller : ControllerBase
    {
        private readonly TodoContext _context;

        public AddFolks1Controller(TodoContext context)
        {
            _context = context;
        }

        // GET: api/AddFolks1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddFolk>>> GetAddFolk()
        {
          if (_context.AddFolk == null)
          {
              return NotFound();
          }
            return await _context.AddFolk.ToListAsync();
        }

        // GET: api/AddFolks1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddFolk>> GetAddFolk(long id)
        {
          if (_context.AddFolk == null)
          {
              return NotFound();
          }
            var addFolk = await _context.AddFolk.FindAsync(id);

            if (addFolk == null)
            {
                return NotFound();
            }

            return addFolk;
        }

        // PUT: api/AddFolks1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddFolk(long id, AddFolk addFolk)
        {
            if (id != addFolk.Id)
            {
                return BadRequest();
            }

            _context.Entry(addFolk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddFolkExists(id))
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

        // POST: api/AddFolks1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddFolk>> PostAddFolk(AddFolk addFolk)
        {
          if (_context.AddFolk == null)
          {
              return Problem("Entity set 'TodoContext.AddFolk'  is null.");
          }
            _context.AddFolk.Add(addFolk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddFolk", new { id = addFolk.Id }, addFolk);
        }

        // DELETE: api/AddFolks1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddFolk(long id)
        {
            if (_context.AddFolk == null)
            {
                return NotFound();
            }
            var addFolk = await _context.AddFolk.FindAsync(id);
            if (addFolk == null)
            {
                return NotFound();
            }

            _context.AddFolk.Remove(addFolk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddFolkExists(long id)
        {
            return (_context.AddFolk?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
