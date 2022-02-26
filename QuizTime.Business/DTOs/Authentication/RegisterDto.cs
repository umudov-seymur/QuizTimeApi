using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime.Business.DTOs.Authentication
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
