using Quiztime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime.Business.DTOs.Quiz
{
    public class QuizGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Timer { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
