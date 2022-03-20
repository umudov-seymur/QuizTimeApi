using Quiztime.Core.Entities;
using Quiztime.Core.Enums;
using QuizTime.Business.DTOs.Question.Answers;
using System;
using System.Collections.Generic;

namespace QuizTime.Business.DTOs.Question
{
    public class QuestionGetForStudentDto
    {
        public Guid Id { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public double Weight { get; set; }
        public bool IsVisited { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<AnswerGetOfStudentDto> Answers { get; set; }
    }
}
