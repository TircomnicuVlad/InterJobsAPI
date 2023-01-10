using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InterJobsAPI.Models;

namespace InterJobsAPI.Models
{
    public partial class InterJobsContext : DbContext
    {
        public InterJobsContext()
        {
        }

        public InterJobsContext(DbContextOptions<InterJobsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:interjobsserver.database.windows.net,1433;Initial Catalog=InterJobs;Persist Security Info=False;User ID=TW_Admin;Password=G3$DJ42Thc5TM$K ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ImageContent);
            });
            
            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DocumentContent);
            });

            modelBuilder.Entity<JobApplication>(entity =>
            {
                entity.ToTable("JobApplication");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.JobID).HasColumnName("JobID");
                entity.Property(e => e.UserID).HasColumnName("UserID");
                entity.Property(e => e.CVID).HasColumnName("CVID");

                entity.HasOne(d => d.Job)
                     .WithMany(p => p.JobApplications)
                     .HasForeignKey(d => d.JobID)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_JobApplication_Job");

                entity.HasOne(d => d.User)
                     .WithMany(p => p.JobApplications)
                     .HasForeignKey(d => d.UserID)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_JobApplication_User");
                
                entity.HasOne(d => d.CV)
                     .WithOne(p => p.JobApplication)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_JobApplication_Document");

            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequiredSkills)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePictureId).HasColumnName("ProfilePictureID");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.ProfilePicture)
                    .WithOne(p => p.User)
                    .HasConstraintName("FK_Image");  

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserType");

                entity.Property(f => f.PhoneNumber)
                    .IsUnicode(false)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<InterJobsAPI.Models.JobApplication> JobApplication { get; set; }
    }
}
