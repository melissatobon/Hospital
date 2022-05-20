﻿using Hospital.Web.Data.Entities;
using Hospital.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {

        }
        public DbSet<Patient> Patients{ get; set; }
       
        public DbSet<LaboratoryExam> LaboratoryExams { get; set; }
        public DbSet<MedicalNote> MedicalNotes { get; set; }
        public DbSet<NurseNote> NurseNotes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }       
       
        public DbSet<Employee> Employees { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>()
                .HasIndex(t => t.Document)
                .IsUnique();

           

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LaboratoryExam>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MedicalNote>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NurseNote>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VitalSign>()
                .HasIndex(t => t.Id)
                .IsUnique();

           

          

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .HasIndex(t => t.Id)
                .IsUnique();

            
        }


    }
}
