using QuizTime.Business.DTOs.Category;
using System;

namespace QuizTime.Business.DTOs.Quiz
{
    public class QuizGetForOwnerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Timer { get; set; }
        public CategoryGetForQuizDto Category { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
