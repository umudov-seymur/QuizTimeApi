using System;

namespace Quiztime.Core.Entities
{
    public class QuizSetting
    {
        public int Id { get; set; }
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public bool IsShuffleQuestions { get; set; }
        public bool IsShuffleAnswers { get; set; }
        public bool IsActive { get; set; }
    }
}
