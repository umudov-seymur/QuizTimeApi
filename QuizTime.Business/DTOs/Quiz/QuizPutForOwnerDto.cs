using Quiztime.Core.Entities;
using System;

namespace QuizTime.Business.DTOs.Quiz
{
    public class QuizPutForOwnerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int? Timer { get; set; }
    }
}
