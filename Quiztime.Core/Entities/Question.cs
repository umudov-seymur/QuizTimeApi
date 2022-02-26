using System;
using System.Collections.Generic;

namespace Quiztime.Core.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public double Weight { get; set; }
        public bool IsVisited { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
