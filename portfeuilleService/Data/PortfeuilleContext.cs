using Microsoft.EntityFrameworkCore;
using portfeuilleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfeuilleService.Data
{
    public class PortfeuilleContext : DbContext
    {
        //PortfeuilleContext() : base("Portfeuille") { }
        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Historique> Historiques { get; set; }

        public DbSet<Periodique> Periodiques { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=portfeuille;Trusted_Connection=True;ConnectRetryCount=0");
            base.OnConfiguring(optionsBuilder);
        }

        public void seed()
        {
            Personnes.Add(new Personne { Nom = "khalifa", Prenom = "rassame",Adresse="tanger",Email="khalifa@gmail.com",Pass="123456",Image="kfuul" });
        }
    }
}
