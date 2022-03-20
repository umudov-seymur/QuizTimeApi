using System;

namespace Quiztime.Core.Entities
{
    public class ResultAnswer
    {
        public int Id { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public Guid AnswerId { get; set; }
        public Answer Answer { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
