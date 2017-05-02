using System;

namespace WYF.WebAPI.Models.Enums.Common
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
