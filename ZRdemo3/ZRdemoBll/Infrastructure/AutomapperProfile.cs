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
            this.CreateMap<Coach, CoachDTO>().ForMember(c => c.Trainings, opt => opt.MapFrom(src => src.Trainings)).ReverseMap();

            this.CreateMap<GroupOfStudents, GroupOfStudentsDTO>().ForMember(g => g.Students, opt => opt.MapFrom(src => src.Students))
                                                                 .ForMember(g => g.Trainings, opt => opt.MapFrom(src => src.Trainings))
                                                                 .ReverseMap();

            this.CreateMap<Guest, GuestDTO>().ReverseMap();

            this.CreateMap<GuestTraining, GuestTrainingDTO>().ReverseMap();

            this.CreateMap<Gym, GymDTO>().ReverseMap();

            this.CreateMap<Student, StudentDTO>().ForMember(s => s.GroupOfStudentsDTO, opt => opt.MapFrom(src => src.GroupOfStudents)).ReverseMap();

            this.CreateMap<Training, TrainingDTO>().ForMember(t => t.Gym, opt => opt.MapFrom(src => src.Gym))
                                                   .ForMember(t => t.Coach, opt => opt.MapFrom(src => src.Coach))
                                                   .ForMember(t => t.GroupOfStudents, opt => opt.MapFrom(src => src.GroupOfStudents)).ReverseMap();
        }
    }
}
