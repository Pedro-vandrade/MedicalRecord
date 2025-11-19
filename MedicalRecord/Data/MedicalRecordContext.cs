using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalRecord.Models;

namespace MedicalRecord.Data
{
    public class MedicalRecordContext : DbContext
    {
        public MedicalRecordContext(DbContextOptions<MedicalRecordContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; } = default!;
        public DbSet<Physician> Physicians { get; set; } = default!;
        public DbSet<PatientHistory> PatientHistories { get; set; } = default!;

        public DbSet<Appointment> Appointments { get; set; } = default!;

        public DbSet<Prescription> Prescriptions { get; set; } = default!;
    }
}
