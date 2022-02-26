using System;
using System.Collections.Generic;
using System.Text;

namespace Quiztime.Core.Interfaces
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
