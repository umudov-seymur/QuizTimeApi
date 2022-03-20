using QuizTime.Business.DTOs.Category;
using QuizTime.Business.DTOs.Quiz.Setting;
using System;

namespace QuizTime.Business.DTOs.Quiz
{
    public class QuizGetForStudent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int QuestionsCount { get; set; }
        public string Description { get; set; }
        public int? Timer { get; set; }
        public DateTime? StartedAt { get; set; }
        public QuizSettingGetDto Setting { get; set; }
        public CategoryGetForQuizDto Category { get; set; }
        public string Password { get; set; }
    }
}
