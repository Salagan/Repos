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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Coach>().HasMany<GroupOfStudents>(g => g.GroupOfStudents)
        //        .WithOne(c => c.Coach)
        //        .HasForeignKey(c => c.CoachId);
        //    modelBuilder.Entity<TrainingDay>().HasMany<Coach>(c => c.Coaches)
        //        .WithMany(t => t.TrainingDays)
        //        .UsingEntity<TrainingDayCoach>(
        //         tc => tc
        //         .HasOne(c => c.Coach)
        //         .WithMany(tc => tc.TrainingDayCoaches)
        //         .HasForeignKey(c => c.CoachId)),
        //        tc => tc
        //        .HasOne(td => td.TrainingDay)
        //}
    }
}
