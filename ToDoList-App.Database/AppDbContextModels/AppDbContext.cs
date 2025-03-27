using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList_App.Database.AppDbContextModels;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
     public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Goal> Goals { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Category>().ToTable("Category"); 
        modelBuilder.Entity<User>().ToTable("User"); 
        modelBuilder.Entity<Task>().ToTable("Task"); 
        modelBuilder.Entity<Goal>().ToTable("Goal"); 

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Category_Name).IsRequired().HasMaxLength(50);
            entity.Property(entity => entity.Description).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(10);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Age).IsRequired();
            entity.Property(e => e.Gender).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            entity.Property(e => e.OTP).HasMaxLength(50);
            entity.Property(e => e.Otp_Exp).IsRequired();
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.TaskName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.dateTime).IsRequired();
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Priority).IsRequired().HasMaxLength(50);
            entity.Property(e => e.C_Id).IsRequired();
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            entity.Property(e => e.DateTime).IsRequired();
            entity.Property(e => e.Duration).IsRequired();
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
            entity.Property(e => e.T_Id).IsRequired();
        });
    }
}
