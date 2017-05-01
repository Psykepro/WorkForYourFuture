using System;

namespace WYF.WebAPI.Models.Enums.Job
{
    [Flags]
    public enum LanguageLevel : byte
    {
        Native,
        Fluent,
        VeryGood,
        Good,
        Basic
    }
}
