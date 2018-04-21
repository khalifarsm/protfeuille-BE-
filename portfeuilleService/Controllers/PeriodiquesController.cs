using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfeuilleService.Data;
using portfeuilleService.Models;

namespace portfeuilleService.Controllers
{
    [Produces("application/json")]
    [Route("api/Periodiques")]
    public class PeriodiquesController : Controller
    {
        private readonly PortfeuilleContext _context;

        public PeriodiquesController(PortfeuilleContext context)
        {
            _context = context;
        }

        // GET: api/Periodiques
        [HttpGet]
        public IEnumerable<Periodique> GetPeriodiques()
        {
            return _context.Periodiques;
        }

        // GET: api/Periodiques/email/password
        [HttpGet("{login}/{pass}")]
        public async Task<IActionResult> GetPeriodique([FromRoute] String login, [FromRoute] String pass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personne = await _context.Personnes.SingleOrDefaultAsync(m => m.Email.Equals(login));
            if (personne == null)
            {
                return NotFound();
            }

            if (!personne.Pass.Equals(pass))
            {
                return NotFound();
            }
            var periodiques = _context.Periodiques.Where(h => h.Personne == personne).ToList();
            return Ok(periodiques);
        }

        // PUT: api/Periodiques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeriodique([FromRoute] int id, [FromBody] Periodique periodique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != periodique.PeriodiqueID)
            {
                return BadRequest();
            }

            _context.Entry(periodique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodiqueExists(id))
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

        // POST: api/Periodiques
        [HttpPost]
        public async Task<IActionResult> PostPeriodique([FromBody] Periodique periodique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Periodiques.Add(periodique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeriodique", new { id = periodique.PeriodiqueID }, periodique);
        }

        // DELETE: api/Periodiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriodique([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var periodique = await _context.Periodiques.SingleOrDefaultAsync(m => m.PeriodiqueID == id);
            if (periodique == null)
            {
                return NotFound();
            }

            _context.Periodiques.Remove(periodique);
            await _context.SaveChangesAsync();

            return Ok(periodique);
        }

        private bool PeriodiqueExists(int id)
        {
            return _context.Periodiques.Any(e => e.PeriodiqueID == id);
        }
    }
}