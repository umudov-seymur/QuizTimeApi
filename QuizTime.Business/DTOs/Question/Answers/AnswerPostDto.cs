namespace QuizTime.Business.DTOs.Question.Answers
{
    public class AnswerPostDto
    {
        public string QuestionId { get; set; }
        public string Content { get; set; }
        public bool IsRightAnswer { get; set; }
    }
}
