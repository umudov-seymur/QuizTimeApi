using System;

namespace Quiztime.Core.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public DateTime StartedAt { get; set; }
    }
}
