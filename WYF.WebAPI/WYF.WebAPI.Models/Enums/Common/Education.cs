using System;

namespace WYF.WebAPI.Models.Enums.Common
{
    [Flags]
    public enum Education : byte
    {
        NotNecessary,
        SecondaryEducation,
        HigherEducation,
    }
}
