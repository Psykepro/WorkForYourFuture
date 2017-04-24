using System;

namespace WYF.WebAPI.Models.Enums.Job
{
    [Flags]
    public enum WorkTime : byte
    {
        FullTime,
        PartTime,
        Freelancer,
        HourlyBases,
    }
}
