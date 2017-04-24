using System;

namespace WYF.WebAPI.Models.Enums.Job
{
    [Flags]
    public enum HierarchyLevel : byte
    {
        NonQualifiedWorkers,
        AdministrativeAndSupportStaff,
        NonManagerialExpertStaff,
        MiddleManagement,
        TopAndSeniorManagement
    }
}
