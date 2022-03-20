using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime.Business.Exceptions
{
    public class QuizIsAlreadyInProgressException : Exception
    {
        public QuizIsAlreadyInProgressException(string message) : base(message)
        {
        }
    }
}
