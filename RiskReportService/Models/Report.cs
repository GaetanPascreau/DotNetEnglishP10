namespace RiskReportService.Models
{
    public class Report
    {
        public string PatientName { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        public string RiskLevel { get; set; }
        public TriggerTermList triggerTermList { get; set; }
    }
}
