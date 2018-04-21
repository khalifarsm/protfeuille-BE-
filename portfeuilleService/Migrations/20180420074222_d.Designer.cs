﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using portfeuilleService.Data;
using System;

namespace portfeuilleService.Migrations
{
    [DbContext(typeof(PortfeuilleContext))]
    [Migration("20180420074222_d")]
    partial class d
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("portfeuilleService.Models.Historique", b =>
                {
                    b.Property<int>("HistoriqueID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Commentaire");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("PeriodiqueID");

                    b.Property<int?>("PersonneID");

                    b.Property<bool>("isRevenu");

                    b.Property<int>("valeur");

                    b.HasKey("HistoriqueID");

                    b.HasIndex("PeriodiqueID");

                    b.HasIndex("PersonneID");

                    b.ToTable("Historiques");
                });

            modelBuilder.Entity("portfeuilleService.Models.Periodique", b =>
                {
                    b.Property<int>("PeriodiqueID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Commentaire");

                    b.Property<int>("Periode");

                    b.Property<int?>("PersonneID");

                    b.Property<bool>("isRevenu");

                    b.Property<int>("valeur");

                    b.HasKey("PeriodiqueID");

                    b.HasIndex("PersonneID");

                    b.ToTable("Periodiques");
                });

            modelBuilder.Entity("portfeuilleService.Models.Personne", b =>
                {
                    b.Property<int>("PersonneID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresse");

                    b.Property<string>("Email");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Nom");

                    b.Property<string>("Pass");

                    b.Property<string>("Prenom");

                    b.HasKey("PersonneID");

                    b.ToTable("Personnes");
                });

            modelBuilder.Entity("portfeuilleService.Models.Historique", b =>
                {
                    b.HasOne("portfeuilleService.Models.Periodique", "Periodique")
                        .WithMany()
                        .HasForeignKey("PeriodiqueID");

                    b.HasOne("portfeuilleService.Models.Personne", "Personne")
                        .WithMany()
                        .HasForeignKey("PersonneID");
                });

            modelBuilder.Entity("portfeuilleService.Models.Periodique", b =>
                {
                    b.HasOne("portfeuilleService.Models.Personne", "Personne")
                        .WithMany()
                        .HasForeignKey("PersonneID");
                });
#pragma warning restore 612, 618
        }
    }
}
