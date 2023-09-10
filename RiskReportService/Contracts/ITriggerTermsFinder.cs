using RiskReportService.Models;

namespace RiskReportService.Contracts
{
    public interface ITriggerTermsFinder
    {
        Task<TriggerTermList> CountTriggerTerms(int patientId);
    }
}
