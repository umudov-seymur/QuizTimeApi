using AutoMapper;
using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.Category;
using QuizTime.Business.DTOs.Question;
using QuizTime.Business.DTOs.Question.Answers;
using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.DTOs.Quiz.Setting;
using QuizTime.Business.DTOs.QuizPassword;
using QuizTime.Business.DTOs.Result;
using System.Linq;

namespace QuizTime.Business.Profiles
{
    class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<QuizPostForOwnerDto, Quiz>()
               .ForMember(x => x.Password, opt => opt.Ignore());

            CreateMap<QuizGetForOwnerDto, Quiz>().ReverseMap()
                .ForMember(d => d.Password, quiz => quiz.MapFrom(quiz => quiz.Password.Content))
                .ForMember(d => d.TotalPoint, quiz => quiz.MapFrom(quiz => quiz.Questions.Select(d => d.Weight).Sum()));

            CreateMap<QuizGetForStudent, Quiz>().ReverseMap()
                .ForMember(d => d.Password, quiz => quiz.MapFrom(quiz => quiz.Password.Content))
                .ForMember(d => d.QuestionsCount, opt => opt.MapFrom(quiz => quiz.Questions.Count));

            CreateMap<Quiz, QuizGetOfJoinedStudentDto>()
                   .ForMember(d => d.Password, quiz => quiz.MapFrom(quiz => quiz.Password.Content));

            CreateMap<QuizPutForOwnerDto, Quiz>()
                .ForMember(x => x.Password, opt => opt.Ignore());

            CreateMap<QuizPasswordGetDto, Password>().ReverseMap();

            CreateMap<Category, CategoryGetForQuizDto>();
            CreateMap<Category, CategoryGetDto>()
                .ForMember(d => d.QuizCount, opt => opt.MapFrom(src => src.Quizzes.Count));

            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();

            CreateMap<Question, QuestionGetOfTeacherDto>();
            CreateMap<Question, QuestionGetForStudentDto>();
            CreateMap<QuestionPostDto, Question>();

            CreateMap<Answer, AnswerGetOfTeacherDto>();
            CreateMap<Answer, AnswerGetOfStudentDto>();
            CreateMap<AnswerPostDto, Answer>();

            CreateMap<QuizSetting, QuizSettingGetDto>();
            CreateMap<QuizSettingPutDto, QuizSetting>();

            CreateMap<Result, ResultGetOfJoinedStudent>();
        }
    }
}
