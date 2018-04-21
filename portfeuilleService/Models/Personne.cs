using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portfeuilleService.Models
{
    public class Personne
    {
        [key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonneID { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public String Adresse { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        public String Pass { get; set; }

        [MaxLength]
        public String Image { get; set; }

        //public virtual ICollection<Historique> Historiques { get; set; }

        //public virtual ICollection<Periodique> Periodiques { get; set; }
    }
}
