using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portfeuilleService.Models
{
    public class Periodique
    {
        [key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeriodiqueID { get; set; }

        public int valeur { get; set; }

        public bool isRevenu { get; set; }

        public String Commentaire { get; set; }

        public int Periode { get; set; }

        public virtual Personne Personne { get; set; }
    }
}
