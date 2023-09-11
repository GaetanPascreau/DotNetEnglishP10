using System.ComponentModel;

namespace RiskReportService.Data
{

    /// <summary>
    /// trigger terms to look for inside notes, in order to determine Diabetes Risk factor and edit a Risk report for a patient.
    /// This list can be updated as needed.
    /// </summary>
    public class TriggerTerms
    {
        public List<String> triggerTerms = new List<string>
        {
            "Hemoglobin A1C",
            "Microalbumin",
            "Body Height",
            "Body Weight",
            "Smoker",
            "Abnormal",
            "Cholesterol",
            "Dizziness",
            "Relapse",
            "Reaction",
            "Antibodies"
        };   
    }
}
