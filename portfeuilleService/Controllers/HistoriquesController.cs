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
    [Route("api/Historiques")]
    public class HistoriquesController : Controller
    {
        private readonly PortfeuilleContext _context;

        public HistoriquesController(PortfeuilleContext context)
        {
            _context = context;
        }
        // GET: api/Historiques
        [HttpGet]
        public IEnumerable<Historique> GetHistoriques()
        {
            /*var personne = new Personne { Nom = "rassame", Prenom = "khalifa", Pass = "123456", Adresse = "tanger", Email = "khalifa@gmail.com", Image = new byte[100] };
            _context.Personnes.Add(personne);
            var historique = new List<Historique>();
            var periodique = new List<Periodique>();
            historique.Add(new Historique { valeur = 10, isRevenu = true, Commentaire = "historique", Date = DateTime.Now, Personne = personne });
            historique.Add(new Historique { valeur = 60, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(1, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 50, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(2, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 20, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(4, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 25, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(6, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 50, isRevenu = false, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(9, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 32, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(10, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 45, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(11, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 95, isRevenu = false, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(13, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 78, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(14, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 25, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(17, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 52, isRevenu = false, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(20, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 46, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(21, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 91, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(22, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 19, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(24, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 32, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(26, 0, 0, 0, 0), Personne = personne });
            historique.Add(new Historique { valeur = 50, isRevenu = true, Commentaire = "historique", Date = DateTime.Now - new TimeSpan(27, 0, 0, 0, 0), Personne = personne });


            periodique.Add(new Periodique { valeur = 100, isRevenu = false, Commentaire = "periodique", Periode = 30, Personne = personne });
            periodique.Add(new Periodique { valeur = 150, isRevenu = true, Commentaire = "periodique", Periode = 10, Personne = personne });
            periodique.Add(new Periodique { valeur = 140, isRevenu = true, Commentaire = "periodique", Periode = 15, Personne = personne });
            periodique.Add(new Periodique { valeur = 120, isRevenu = false, Commentaire = "periodique", Periode = 20, Personne = personne });
            periodique.Add(new Periodique { valeur = 90, isRevenu = true, Commentaire = "periodique", Periode = 30, Personne = personne });
            periodique.Add(new Periodique { valeur = 80, isRevenu = false, Commentaire = "periodique", Periode = 40, Personne = personne });

            _context.Historiques.AddRange(historique);
            _context.Periodiques.AddRange(periodique);
            _context.SaveChanges();*/
            return _context.Historiques;
        }

        // GET: api/Historiques/5
        [HttpGet("{login}/{pass}")]
        public async Task<IActionResult> GetHistorique([FromRoute] String login, [FromRoute]String pass)
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
            var historiques = _context.Historiques.Where(h => h.Personne == personne).ToList();
            var periodiques = _context.Periodiques.Where(h => h.Personne == personne).ToList();
            foreach (var periodique in periodiques)
            {
                bool found = false;
                foreach (var historique in historiques)
                {
                    if (historique.Periodique != null)
                    {
                        if (historique.Periodique.Equals(periodique) & !found)
                        {
                            found = true;
                            DateTime d = historique.Date;
                            while (d.AddDays(periodique.Periode) < DateTime.Now)
                            {
                                d = d.AddDays(periodique.Periode);
                                historiques.Add(new Historique { valeur = periodique.valeur, isRevenu = periodique.isRevenu, Commentaire = periodique.Commentaire, Date = d, Personne = periodique.Personne });
                            }
                        }
                    }
                }
                if (!found)
                {
                    DateTime d = DateTime.Parse("08/04/2018");
                    while (d.AddDays(periodique.Periode) < DateTime.Now)
                    {
                        d = d.AddDays(periodique.Periode);
                        historiques.Add(new Historique { valeur = periodique.valeur, isRevenu = periodique.isRevenu, Commentaire = periodique.Commentaire, Date = d, Personne = periodique.Personne });
                    }
                }
            }
            _context.SaveChanges();
            return Ok(historiques.OrderBy(h=>h.Date));
        }

        // PUT: api/Historiques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorique([FromRoute] int id, [FromBody] Historique historique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historique.HistoriqueID)
            {
                return BadRequest();
            }

            _context.Entry(historique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriqueExists(id))
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

        // POST: api/Historiques
        [HttpPost]
        public async Task<IActionResult> PostHistorique([FromBody] Historique historique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Historiques.Add(historique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorique", new { id = historique.HistoriqueID }, historique);
        }

        // DELETE: api/Historiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorique([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historique = await _context.Historiques.SingleOrDefaultAsync(m => m.HistoriqueID == id);
            if (historique == null)
            {
                return NotFound();
            }

            _context.Historiques.Remove(historique);
            await _context.SaveChangesAsync();

            return Ok(historique);
        }

        private bool HistoriqueExists(int id)
        {
            return _context.Historiques.Any(e => e.HistoriqueID == id);
        }
    }
}