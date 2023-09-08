using System.ComponentModel;

namespace RiskReportService.Data
{
    public enum TriggersEnum
    {
        [Description("Hemoglobin A1C")]
        HemoglobinA1C,

        [Description("Microalbumin")]
        Microalbumin,

        [Description("Body Height")]
        Body_Height,

        [Description("Body Weight")]
        Body_Weight,

        [Description("Smoker")]
        Smoker,

        [Description("Abnormal")]
        Abnormal,

        [Description("Cholesterol")]
        Cholesterol,

        [Description("Dizziness")]
        Dizziness,

        [Description("Relapse")]
        Relapse,

        [Description("Reaction")]
        Reaction,

        [Description("Antibodies")]
        Antibodies
    }
}
