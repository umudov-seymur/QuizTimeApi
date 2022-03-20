using System;
using System.Collections.Generic;

namespace Quiztime.Core.Entities
{
    public class Password
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Guid? QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
