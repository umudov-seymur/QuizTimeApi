using System;
using System.Collections.Generic;

namespace Quiztime.Core.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Timer { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public int PasswordId { get; set; }
        public Password Password { get; set; }
        public QuizSetting Setting { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
