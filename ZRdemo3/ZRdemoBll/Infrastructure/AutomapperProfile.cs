using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZRdemoContracts.ModelsDTO;
using ZRdemoData.Models;

namespace ZRdemoBll.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<Coach, CoachDTO>().ReverseMap();
            this.CreateMap<GroupOfStudents, GroupOfStudentsDTO>().ReverseMap();
            this.CreateMap<Guest, GuestDTO>().ReverseMap();
            this.CreateMap<GuestTraining, GuestTrainingDTO>().ReverseMap();
            this.CreateMap<Gym, GymDTO>().ReverseMap();
            this.CreateMap<Student, StudentDTO>().ReverseMap();
            this.CreateMap<Training, TrainingDTO>().ReverseMap();
        }
    }
}
