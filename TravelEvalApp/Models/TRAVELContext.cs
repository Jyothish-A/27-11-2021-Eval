using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelEvalApp.Models
{
    public partial class TRAVELContext : DbContext
    {
        public TRAVELContext()
        {
        }

        public TRAVELContext(DbContextOptions<TRAVELContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Request> Request { get; set; }


        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=JYOTHISHA\\SQLEXPRESS; Initial Catalog=TRAVEL; Integrated security=True");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__EMPLOYEE__16EBFA268297FB30");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmpId).HasColumnName("EMP_ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Loginid).HasColumnName("LOGINID");

                entity.Property(e => e.Phone).HasColumnName("PHONE");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Loginid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLOG");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Loginid).HasColumnName("LOGINID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usertype)
                    .IsRequired()
                    .HasColumnName("USERTYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("PROJECT");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.ProjectName)
                    .HasColumnName("PROJECT_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("REQUEST");

                entity.Property(e => e.Requestid).HasColumnName("REQUESTID");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasColumnName("DESTINATION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("EMP_ID");

                entity.Property(e => e.FromDate)
                    .HasColumnName("FROM_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Mode)
                    .HasColumnName("MODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoDays).HasColumnName("NO_DAYS");

                entity.Property(e => e.Priority)
                    .HasColumnName("PRIORITY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("SOURCE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate)
                    .HasColumnName("TO_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.TravelCause)
                    .HasColumnName("TRAVEL_CAUSE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
