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

        public DbSet<TrainingDay> TrainingDays { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<GroupOfStudents> GroupOfStudents { get; set; }

        public DbSet<GuestCoach> GuestCoaches { get; set; }

        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne<GroupOfStudents>(s => s.GroupOfStudents)
                .WithMany(g => g.Students);

            modelBuilder.Entity<GroupOfStudents>()
                .HasMany<TrainingDay>(g => g.TrainingDays)
                .WithMany(t => t.GroupOfStudents);

            modelBuilder.Entity<Coach>()
                .HasMany<TrainingDay>(c => c.TrainingDays)
                .WithMany(t => t.Coaches);

            modelBuilder.Entity<Gym>()
                .HasMany<TrainingDay>(g => g.TrainingDays)
                .WithMany(t => t.Gyms);
        }
    }
}
