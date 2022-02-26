using QuizTime.Business.Validators.Authenticate;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime.Business.DTOs.Authentication
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
