using Hospital.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {

        }
        public DbSet<Patient> Patients{ get; set; }
        public DbSet<ContactPatient> ContactPatients { get; set; }
        public DbSet<Egress> Egresses { get; set; }
        public DbSet<LaboratoryExam> LaboratoryExams { get; set; }
        public DbSet<MedicalNote> MedicalNotes { get; set; }
        public DbSet<NurseNote> NurseNotes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }       
        public DbSet<AntecedentStaff> AntecedentsStaffs { get; set; }
        public DbSet<AntecedentFamiliar> AntecedentsFamily { get; set; }
        public DbSet<AntecedentSurgical> AntecedentsSurgical { get; set; }
        public DbSet<AntecedentAllergic> AntecedentsAllergics { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>()
                .HasIndex(t => t.Document)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContactPatient>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Egress>()
                .HasIndex(t => t.Id)
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
            modelBuilder.Entity<AntecedentStaff>()
                .HasIndex(t => t.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AntecedentFamiliar>()
                .HasIndex(t => t.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AntecedentSurgical>()
                .HasIndex(t => t.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AntecedentAllergic>()
                .HasIndex(t => t.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(t => t.Id)
                .IsUnique();
        }


    }
}
