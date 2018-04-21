using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portfeuilleService.Models
{
    public class Historique
    {
        [key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoriqueID { get; set; }

        public int valeur { get; set; }

        public bool isRevenu { get; set; }

        public String Commentaire { get; set; }

        public DateTime Date { get; set; }

        public virtual Periodique Periodique { get; set; }

        public virtual Personne Personne { get; set; }
    }
}
