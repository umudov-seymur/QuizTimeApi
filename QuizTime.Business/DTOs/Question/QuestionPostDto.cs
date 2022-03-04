using Quiztime.Core.Enums;

namespace QuizTime.Business.DTOs.Question
{
    public class QuestionPostDto
    {
        public string QuizId { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public double Weight { get; set; }
    }
}
