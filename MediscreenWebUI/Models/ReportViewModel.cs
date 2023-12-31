﻿namespace MediscreenWebUI.Models
{
    public class ReportViewModel
    {
        public string PatientName { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        public string RiskLevel { get; set; }
        public TriggerTermListViewModel triggerTermList { get; set; }
    }
}
