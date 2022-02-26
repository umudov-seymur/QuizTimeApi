using System;
using System.Collections.Generic;

namespace Quiztime.Core.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Quiz> Quizzes { get; set; }
    }
}
