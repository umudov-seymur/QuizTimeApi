using System;
using System.Collections.Generic;

namespace Quiztime.Core.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool IsRightAnswer { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
