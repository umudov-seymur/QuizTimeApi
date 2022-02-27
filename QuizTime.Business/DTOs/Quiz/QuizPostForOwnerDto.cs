using Quiztime.Core.Entities;

namespace QuizTime.Business.DTOs.Quiz
{
    public class QuizPostForOwnerDto
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int? Timer { get; set; }
    }
}
