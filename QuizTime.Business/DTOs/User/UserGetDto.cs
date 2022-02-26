using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime.Business.DTOs.User
{
    public class UserGetDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}
