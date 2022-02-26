using System;
using System.Collections.Generic;
using System.Text;

namespace Quiztime.Core.Interfaces
{
    public interface IAuditInfo
    {
        DateTime CreatedAt { get; set; }

        DateTime? UpdatedAt{ get; set; }
    }
}
