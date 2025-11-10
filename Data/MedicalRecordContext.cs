using Microsoft.EntityFrameworkCore;
using MedicalRecord.Models;
// using MedicalRecord.Enums; // Mantenha este se você criou a pasta Enums

namespace MedicalRecord.Data
{
    public class MedicalRecordContext : DbContext
    {
        public MedicalRecordContext(DbContextOptions<MedicalRecordContext> options)
            : base(options)
        {
        }

        // --- DbSets (Tabelas) ---
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<PatientEntry> PatientEntries { get; set; }
        public DbSet<PatientHistory> PatientHistories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        // DbSets Faltantes - Remova os comentários APÓS criar as classes Allergy.cs e Certificate.cs
        // public DbSet<Allergy> Allergies { get; set; } 
        // public DbSet<Certificate> Certificates { get; set; } 


        // --- Configuração dos Relacionamentos e Restrições ---
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Restrições de Unicidade
            // 1. Patient.CPF
            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.CPF)
                .IsUnique();

            // 2. Medic.CRM
            modelBuilder.Entity<Medic>()
                .HasIndex(m => m.CRM)
                .IsUnique();

            // Relacionamento 1:N PatientEntry -> Patient
            modelBuilder.Entity<PatientEntry>()
                .HasOne(pe => pe.Patient)
                .WithMany(p => p.PatientEntry)
                .HasForeignKey(pe => pe.PatientID);

            // Relacionamento 1:N PatientEntry -> Medic
            modelBuilder.Entity<PatientEntry>()
                .HasOne(pe => pe.Medic)
                .WithMany(m => m.PatientEntry)
                .HasForeignKey(pe => pe.MedicID);

            // Relacionamento 1:1 Patient -> PatientHistory
            modelBuilder.Entity<PatientHistory>()
                .HasOne(ph => ph.Patient);
              /*  .WithOne(p => p.History) // Assumindo 'History' no model Patient
                .HasForeignKey<PatientHistory>(ph => ph.PatientId);*/

            // Relacionamento 1:N Opcional PatientEntry -> Test
            modelBuilder.Entity<Test>()
                .HasOne(t => t.Entry)
                .WithMany(pe => pe.RequiredExams) // Coleção em PatientEntry.cs
                .HasForeignKey(t => t.EntryId)
                .IsRequired(false);

            // Relacionamento 1:N Obrigatório PatientEntry -> Treatment
            modelBuilder.Entity<Treatment>()
                .HasOne(t => t.PatientEntry)
                .WithMany(pe => pe.PrescribedTreatment) // Coleção em PatientEntry.cs
                .HasForeignKey(t => t.EntryID)
                .IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}