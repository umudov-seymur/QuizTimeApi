using Microsoft.AspNetCore.Identity;
using Quiztime.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiztime.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Audit info
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
