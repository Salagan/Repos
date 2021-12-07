using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZRdemoData.Models
{
    public class ZRdemoContext : DbContext
    {
        public ZRdemoContext(DbContextOptions<ZRdemoContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<GroupOfStudents> GroupOfStudents { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<GuestTraining> GuestTrainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student
            modelBuilder.Entity<Student>()
                .HasOne<GroupOfStudents>(s => s.GroupOfStudents)
                .WithMany(g => g.Students);

            // Group of Students
            modelBuilder.Entity<GroupOfStudents>()
                .HasMany<Training>(g => g.Trainings)
                .WithOne(t => t.GroupOfStudents);

            // Coach
            modelBuilder.Entity<Coach>()
                .HasMany<Training>(c => c.Trainings)
                .WithOne(t => t.Coach);

            // Training
            modelBuilder.Entity<Training>()
                .HasMany(t => t.GuestTrainigs)
                .WithOne(gut => gut.Training);

            // Guest
            modelBuilder.Entity<Guest>()
                .HasMany(gu => gu.GuestTrainings)
                .WithOne(gut => gut.Guest);

            // Join tables keys
            modelBuilder.Entity<GuestTraining>()
                .HasKey(gut => new { gut.GuestId, gut.TrainingId });
        }
    }
}
