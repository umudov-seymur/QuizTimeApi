using QuizTime.Business.DTOs.Category;
using QuizTime.Business.DTOs.Question;
using QuizTime.Business.DTOs.Quiz.Setting;
using System;
using System.Collections.Generic;

namespace QuizTime.Business.DTOs.Quiz
{
    public class QuizGetOfJoinedStudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Timer { get; set; }
        public double TotalPoint { get; set; }
        public DateTime StartedAt { get; set; }
        public QuizSettingGetDto Setting { get; set; }
        public CategoryGetForQuizDto Category { get; set; }
        public IList<QuestionGetForStudentDto> Questions { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
