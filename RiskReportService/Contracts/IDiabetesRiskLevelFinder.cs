namespace RiskReportService.Contracts
{
    public interface IDiabetesRiskLevelFinder
    {
        Task<string> DetermineRiskLevel(int triggersNumber, int patientAge, char patientSex);
    }
}
