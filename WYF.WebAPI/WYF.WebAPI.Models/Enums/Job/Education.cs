using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYF.WebAPI.Models.Enums.Job
{
    [Flags]
    public enum Education : byte
    {
        SecondaryEducation,
        HigherEducation
    }
}
