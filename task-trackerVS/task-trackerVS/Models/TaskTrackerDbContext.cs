using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace task_trackerVS.Models
{
    public partial class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext()
        {
        }

        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WorkSpace> WorkSpaces { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;database=task-Tracker_DB;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.IdCard)
                    .HasName("PRIMARY");

                entity.ToTable("cards");

                entity.HasIndex(e => e.IdSection, "id_section");

                entity.HasIndex(e => e.IdUser, "id_user");

                entity.Property(e => e.IdCard).HasColumnName("id_card");

                entity.Property(e => e.CardLocationY).HasColumnName("cardLocation_Y");

                entity.Property(e => e.Content)
                    .HasMaxLength(700)
                    .HasColumnName("content");

                entity.Property(e => e.Heading)
                    .HasMaxLength(30)
                    .HasColumnName("heading");

                entity.Property(e => e.IdSection).HasColumnName("id_section");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.NameCard)
                    .HasMaxLength(30)
                    .HasColumnName("name_card");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.IdSection)
                    .HasName("PRIMARY");

                entity.ToTable("sections");

                entity.HasIndex(e => e.IdWorkSpace, "id_work_space");

                entity.Property(e => e.IdSection).HasColumnName("id_section");

                entity.Property(e => e.HeadingSection)
                    .HasMaxLength(30)
                    .HasColumnName("heading_section");

                entity.Property(e => e.IdWorkSpace).HasColumnName("id_work_space");

                entity.Property(e => e.NameSection)
                    .HasMaxLength(30)
                    .HasColumnName("name_section");

                entity.Property(e => e.SectionLocationX).HasColumnName("sectionLocation_X");

                entity.Property(e => e.SectionLocationY).HasColumnName("sectionLocation_Y");

                entity.HasOne(d => d.IdWorkSpaceNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.IdWorkSpace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sections_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Login)
                    .HasMaxLength(30)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .HasColumnName("role")
                    .HasDefaultValueSql("'Default'");

                entity.HasMany(d => d.WorkSpaces)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserWorkSpace",
                        l => l.HasOne<WorkSpace>().WithMany().HasForeignKey("WorkSpaceId").HasConstraintName("user_work_space_ibfk_2"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("user_work_space_ibfk_1"),
                        j =>
                        {
                            j.HasKey("UserId", "WorkSpaceId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("user_work_space");

                            j.HasIndex(new[] { "WorkSpaceId" }, "work_space_id");

                            j.IndexerProperty<int>("UserId").HasColumnName("user_id");

                            j.IndexerProperty<int>("WorkSpaceId").HasColumnName("work_space_id");
                        });
            });

            modelBuilder.Entity<WorkSpace>(entity =>
            {
                entity.HasKey(e => e.IdWorkSpace)
                    .HasName("PRIMARY");

                entity.ToTable("work_spaces");

                entity.Property(e => e.IdWorkSpace).HasColumnName("id_work_space");

                entity.Property(e => e.WorkSpaceName)
                    .HasMaxLength(100)
                    .HasColumnName("work_space_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
