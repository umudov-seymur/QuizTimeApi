using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime.Business.Exceptions
{
    public class QuizPasswordExistException : Exception
    {
        public QuizPasswordExistException(string message) : base(message)
        {
        }
    }
}
