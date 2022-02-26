using Microsoft.AspNetCore.Identity;
using Quiztime.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiztime.Core.Entities
{
    public class AppRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public AppRole()
           : this(null)
        {
        }

        public AppRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        // Audit info
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
