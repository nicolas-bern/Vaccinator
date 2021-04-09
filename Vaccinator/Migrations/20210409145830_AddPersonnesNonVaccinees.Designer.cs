﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vaccinator.Models;

namespace Vaccinator.Migrations
{
    [DbContext(typeof(ContexteBDD))]
    [Migration("20210409145830_AddPersonnesNonVaccinees")]
    partial class AddPersonnesNonVaccinees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Vaccinator.Models.Injection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdministration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateRappel")
                        .HasColumnType("TEXT");

                    b.Property<int>("Lot")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonneId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VaccinId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonneId");

                    b.HasIndex("VaccinId");

                    b.ToTable("Injection");
                });

            modelBuilder.Entity("Vaccinator.Models.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsResident")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personnes");
                });

            modelBuilder.Entity("Vaccinator.Models.Vaccin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vaccin");
                });

            modelBuilder.Entity("Vaccinator.Models.Injection", b =>
                {
                    b.HasOne("Vaccinator.Models.Personne", "Personne")
                        .WithMany("Injections")
                        .HasForeignKey("PersonneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vaccinator.Models.Vaccin", "Vaccin")
                        .WithMany("Injections")
                        .HasForeignKey("VaccinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personne");

                    b.Navigation("Vaccin");
                });

            modelBuilder.Entity("Vaccinator.Models.Personne", b =>
                {
                    b.Navigation("Injections");
                });

            modelBuilder.Entity("Vaccinator.Models.Vaccin", b =>
                {
                    b.Navigation("Injections");
                });
#pragma warning restore 612, 618
        }
    }
}
