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

        public DbSet<CoachTrainingDay> CoachTrainingDays { get; set; }

        public DbSet<GroupOfStudentsTrainingDay> GroupOfStudentsTrainingDays { get; set; }

        public DbSet<GymTrainingDay> GymTrainingDays { get; set; }

        public DbSet<GuestTraining> GuestTrainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student
            modelBuilder.Entity<Student>()
                .HasOne<GroupOfStudents>(s => s.GroupOfStudents)
                .WithMany(g => g.Students);

            // Group of Students
            modelBuilder.Entity<GroupOfStudents>()
                .HasMany<GroupOfStudentsTrainingDay>(g => g.GroupOfStudentsTrainingDays)
                .WithOne(gtr => gtr.GroupOfStudents);

            // Coach
            modelBuilder.Entity<Coach>()
                .HasMany<CoachTrainingDay>(c => c.CoachTrainingDays)
                .WithOne(t => t.Coach);

            // Gym
            modelBuilder.Entity<Gym>()
                .HasMany<GymTrainingDay>(g => g.GymTrainingDays)
                .WithOne(t => t.Gym);

            // Training Day
            modelBuilder.Entity<TrainingDay>()
                .HasMany<Training>(td => td.Trainings)
                .WithOne(tr => tr.TrainingDay);

            modelBuilder.Entity<TrainingDay>()
                .HasMany<CoachTrainingDay>(tr => tr.CoacheTrainingDay)
                .WithOne(ctr => ctr.TrainingDay);

            // Training
            modelBuilder.Entity<Training>()
                .HasMany(t => t.GuestTrainings)
                .WithOne(gut => gut.Training);

            // Guest
            modelBuilder.Entity<Guest>()
                .HasMany(gu => gu.GuestTrainings)
                .WithOne(gut => gut.Guest);

            // Guest Coach
            modelBuilder.Entity<GuestCoach>()
                .HasMany(gc => gc.Trainings)
                .WithOne(t => t.GuestCoach);

            // Join tables keys
            modelBuilder.Entity<CoachTrainingDay>()
                .HasKey(ct => new { ct.CoachId, ct.TrainingDayId });

            modelBuilder.Entity<GroupOfStudentsTrainingDay>()
                .HasKey(gtr => new { gtr.GroupOfStudentsId, gtr.TrainingDayId });

            modelBuilder.Entity<GymTrainingDay>()
                .HasKey(gt => new { gt.GymId, gt.TrainingDayID });

            modelBuilder.Entity<GuestTraining>()
                .HasKey(gut => new { gut.GuestId, gut.TrainingId });
        }
    }
}
