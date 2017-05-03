using System;

namespace WYF.WebAPI.Models.Enums.Common
{
    [Flags]
    public enum LanguageLevel : byte
    {
        Basic,
        Good,
        VeryGood,
        Fluent,
        Native,
        
    }
}
