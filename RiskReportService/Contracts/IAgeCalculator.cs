namespace RiskReportService.Contracts
{
    public interface IAgeCalculator
    {
        int CalculateAge(DateTime dateOfBirth);
    }
}
