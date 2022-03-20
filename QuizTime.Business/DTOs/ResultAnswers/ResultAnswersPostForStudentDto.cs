using System.Collections.Generic;

namespace QuizTime.Business.DTOs.ResultAnswers
{
    public class ResultAnswersPostForStudentDto
    {
        public string QuestionId { get; set; }
        public List<AnswersPostForStudentDto> Answers { get; set; }
        public string Content { get; set; }
    }
}
