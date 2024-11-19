using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using _14_MVCTodos.Models;

namespace _14_MVCTodos.Data;

public partial class MvctodoContext : DbContext
{
    public MvctodoContext()
    {
    }

    public MvctodoContext(DbContextOptions<MvctodoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamTodo> TeamTodos { get; set; }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MVCTodo;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC078D867B44");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0708930A36");

            entity.Property(e => e.HireDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Salary).HasDefaultValue(1200m);

            entity.HasOne(d => d.Role).WithMany(p => p.Employees).HasConstraintName("FK__Employees__RoleI__5FB337D6");

            entity.HasOne(d => d.Team).WithMany(p => p.Employees).HasConstraintName("FK__Employees__TeamI__5EBF139D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0766AD6389");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teams__3214EC07101FD6C2");
        });

        modelBuilder.Entity<TeamTodo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeamTodo__3214EC07EC1903EE");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamTodos).HasConstraintName("FK__TeamTodo__TeamId__534D60F1");

            entity.HasOne(d => d.Todo).WithMany(p => p.TeamTodos).HasConstraintName("FK__TeamTodo__TodoId__5441852A");
        });

        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Todos__3214EC07B77686F8");

            entity.Property(e => e.IsDone).HasDefaultValue(false);
            entity.Property(e => e.Status).HasDefaultValue("Pending...");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
