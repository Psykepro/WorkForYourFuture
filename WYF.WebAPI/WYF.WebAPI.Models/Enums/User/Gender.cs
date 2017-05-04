using System;

namespace WYF.WebAPI.Models.Enums.User
{
    [Flags]
    public enum Gender : byte
    {
        NotChosen,
        Male,
        Female
    }
}
