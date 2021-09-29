using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ZRdemo2.Models
{
    public class ZRdemo2Initializer : DropCreateDatabaseIfModelChanges<ZRdemo2Context>
    {
        protected override void Seed(ZRdemo2Context context)
        {
            var students = new List<Student>()
            {
                new Student {FirstName = "Andriy", LastName="Salagan", Age = 31, Gender = Gender.Male, Injury = false, BirthDate = DateTime.Parse("1990-07-12"), PhoneNumber = "+380674561278"},
                new Student {FirstName = "Serhiy", LastName="Pazyurustyi", Age = 29, Gender = Gender.Male, Injury = false, BirthDate = DateTime.Parse("1993-06-11"), PhoneNumber = "+380674561278"},
                new Student {FirstName = "Anton", LastName="Fisher", Age = 32, Gender = Gender.Male, Injury = true, BirthDate = DateTime.Parse("1989-07-26"), PhoneNumber = "+380674561278"}
            };

            var coaches = new List<Coach>()
            {
                new Coach {FirstName = "Anton", LastName = "Maximov", Age = 38, Gender = Gender.Male, Days = TrainingDays.Wednesday, BirthDate = DateTime.Parse("1982-11-06"), PhoneNumber="+380507894562" }
            };
            students.ForEach(x => context.Students.Add(x));
            coaches.ForEach(x => context.Coaches.Add(x));

            context.SaveChanges();

        }
    }
}