using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Models;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DcandidatesController : ControllerBase
    {
        private readonly DonationDBContext _context;

        public DcandidatesController(DonationDBContext context)
        {
            _context = context;
        }

        // GET: api/Dcandidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dcandidate>>> GetDcandidates()
        {
          if (_context.Dcandidates == null)
          {
              return NotFound();
          }
            return await _context.Dcandidates.ToListAsync();
        }

        // GET: api/Dcandidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dcandidate>> GetDcandidate(int id)
        {
          if (_context.Dcandidates == null)
          {
              return NotFound();
          }
            var dcandidate = await _context.Dcandidates.FindAsync(id);

            if (dcandidate == null)
            {
                return NotFound();
            }

            return dcandidate;
        }

        // PUT: api/Dcandidates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDcandidate(int id, Dcandidate dcandidate)
        {
            if (id != dcandidate.Id)
            {
                return BadRequest();
            }

            _context.Entry(dcandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DcandidateExists(id))
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

        // POST: api/Dcandidates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dcandidate>> PostDcandidate(Dcandidate dcandidate)
        {
          if (_context.Dcandidates == null)
          {
              return Problem("Entity set 'DonationDBContext.Dcandidates'  is null.");
          }
            _context.Dcandidates.Add(dcandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDcandidate", new { id = dcandidate.Id }, dcandidate);
        }

        // DELETE: api/Dcandidates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDcandidate(int id)
        {
            if (_context.Dcandidates == null)
            {
                return NotFound();
            }
            var dcandidate = await _context.Dcandidates.FindAsync(id);
            if (dcandidate == null)
            {
                return NotFound();
            }

            _context.Dcandidates.Remove(dcandidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DcandidateExists(int id)
        {
            return (_context.Dcandidates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
