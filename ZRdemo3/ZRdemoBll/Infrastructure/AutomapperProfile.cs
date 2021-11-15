using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZRdemoBll.ModelsDTO;
using ZRdemoData.Models;

namespace ZRdemoBll.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Coach, CoachDTO>().ReverseMap();
            CreateMap<GroupOfStudents, GroupOfStudentsDTO>().ReverseMap();
            CreateMap<Guest, GuestDTO>().ReverseMap();
            CreateMap<GuestTraining, GuestTrainingDTO>().ReverseMap();
            CreateMap<Gym, GymDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Training, TrainingDTO>().ReverseMap();
        }
    }
}
