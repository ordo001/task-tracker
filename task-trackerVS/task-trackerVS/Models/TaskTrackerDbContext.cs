﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace task_trackerVS.Models;

public partial class TaskTrackerDbContext : DbContext
{
    public TaskTrackerDbContext()
    {
    }

    public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=task-tracker_DB;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.IdCard).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdSectionNavigation).WithMany(p => p.Cards)
                .HasForeignKey(d => d.IdSection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cards_ibfk_1");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Cards)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("cards_ibfk_2");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.IdSection).HasName("PRIMARY");

            entity.ToTable("sections");

            entity.Property(e => e.IdSection).HasColumnName("id_section");
            entity.Property(e => e.HeadingSection)
                .HasMaxLength(30)
                .HasColumnName("heading_section");
            entity.Property(e => e.NameSection)
                .HasMaxLength(30)
                .HasColumnName("name_section");
            entity.Property(e => e.SectionLocationX).HasColumnName("sectionLocation_X");
            entity.Property(e => e.SectionLocationY).HasColumnName("sectionLocation_Y");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
