using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime.Business.DTOs.Quiz.Setting
{
    public class QuizSettingGetDto
    {
        public bool IsShuffleQuestions { get; set; }
        public bool IsShuffleAnswers { get; set; }
        public bool IsActive { get; set; }
    }
}
