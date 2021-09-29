using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SymptoMedic.DataAccess.Entities
{
    public partial class symptomedicContext : DbContext
    {
        public symptomedicContext()
        {
        }

        public symptomedicContext(DbContextOptions<symptomedicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorSymptom> DoctorSymptoms { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientContact)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("client_contact");

                entity.Property(e => e.ClientFirstName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("client_firstName");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientLastName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("client_LastName");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.PatientSymptoms)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false)
                    .HasColumnName("patient_symptoms");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Appointme__clien__2739D489");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Appointme__docto__282DF8C2");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.ContactMobile, "UQ__Client__144D470F9E3CA6DD")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Client__AB6E61640C9D098B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.City)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.ContactMobile)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("contact_mobile");

                entity.Property(e => e.Country)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.InsuranceId).HasColumnName("insurance_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.InsuranceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Client__insuranc__208CD6FA");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.HasIndex(e => e.License, "UQ__Doctor__A4E54DE466CB1A26")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Doctor__AB6E6164FEDD5247")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Certifications)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("certifications");

                entity.Property(e => e.DoctorSpeciality).HasColumnName("doctor_speciality");

                entity.Property(e => e.Education)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("education");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.License).HasColumnName("license");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.PracticeAddress)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("practice_address");

                entity.Property(e => e.PracticeCity)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("practice_city");

                entity.Property(e => e.PracticeName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("practice_name");

                entity.Property(e => e.PracticeState)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("practice_state");

                entity.Property(e => e.PracticeZipcode).HasColumnName("practice_zipcode");

                entity.Property(e => e.Sex)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("sex");
            });

            modelBuilder.Entity<DoctorSymptom>(entity =>
            {
                entity.ToTable("Doctor_symptoms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.Symptom)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("symptom");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorSymptoms)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Doctor_sy__docto__2B0A656D");
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.ToTable("Insurance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProviderId).HasColumnName("provider_id");

                entity.Property(e => e.ProviderName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("provider_name");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.From)
                    .HasColumnType("datetime")
                    .HasColumnName("from");

                entity.Property(e => e.To)
                    .HasColumnType("datetime")
                    .HasColumnName("to");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Schedule__doctor__2DE6D218");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
