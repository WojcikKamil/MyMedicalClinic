using ClinicAPIv1.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Data
{
    public class DataContext : IdentityDbContext<ClinicUser, ClinicRole, int, 
        IdentityUserClaim<int>, ClinicUserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Symptom> Symptoms { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<MedicalHistory> MedicalHistories { get; set; }

        public DbSet<AccesCode> AccesCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ClinicUser>()
                .HasMany(ur => ur.ClinicRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<ClinicRole>()
                .HasMany(ur => ur.ClinicRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    
}
