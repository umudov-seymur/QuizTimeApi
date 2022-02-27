using AutoMapper;
using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.DTOs.QuizPassword;

namespace QuizTime.Business.Profiles
{
    class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<QuizPostForOwnerDto, Quiz>()
               .ForMember(x => x.Password, opt => opt.Ignore());

            CreateMap<QuizGetForOwnerDto, Quiz>().ReverseMap()
                .ForMember(dto => dto.Password, quiz => quiz.MapFrom(quiz => quiz.Password.Content));

            CreateMap<QuizPutForOwnerDto, Quiz>()
                .ForMember(x => x.Password, opt => opt.Ignore());

            CreateMap<QuizPasswordGetDto, Password>().ReverseMap();
        }
    }
}
