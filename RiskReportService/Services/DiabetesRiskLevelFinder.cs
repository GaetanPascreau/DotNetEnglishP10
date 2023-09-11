using RiskReportService.Contracts;

namespace RiskReportService.Services
{
    public class DiabetesRiskLevelFinder : IDiabetesRiskLevelFinder
    {
        public async Task<string> DetermineRiskLevel(int triggersNumber, int patientAge, char patientSex)
        {
                Console.WriteLine($"age calculated in DetermineRiskLevel = {patientAge}");
                var riskLevel = "";
                Console.WriteLine($"TriggersNumber used in DetermineRiskLevel = {triggersNumber}");

                var patientSexToString = Char.ToString(patientSex).ToUpper();

                if (patientAge <= 30)
                {
                    if (patientSexToString == "M")
                    {
                        if (triggersNumber >= 5)
                        {
                            riskLevel = "Early Onset";
                        }
                        else if (triggersNumber >= 3)
                        {
                            riskLevel = "In Danger";
                        }
                        else if (triggersNumber > 0)
                        {
                            riskLevel = "Borderline";
                        }
                        else
                        {
                            riskLevel = "None";
                        }
                    }
                    else if (patientSexToString == "F")
                    {
                        if (triggersNumber >= 7)
                        {
                            riskLevel = "Early Onset";
                        }
                        else if (triggersNumber >= 4)
                        {
                            riskLevel = "In Danger";
                        }
                        else if (triggersNumber > 0)
                        {
                            riskLevel = "Borderline";
                        }
                        else
                        {
                            riskLevel = "None";
                        }
                    }
                }
                else if (patientAge > 30)
                {
                    if (triggersNumber >= 8)
                    {
                        riskLevel = "Early Onset";
                    }
                    else if (triggersNumber >= 6)
                    {
                        riskLevel = "In Danger";
                    }
                    else if (triggersNumber >= 2)
                    {
                        riskLevel = "Borderline";
                    }
                    else
                    {
                        riskLevel = "None";
                    }
                }

                Console.WriteLine($"RiskLevel determined in DetermineRiskLevel = {riskLevel}");
                return riskLevel;
        }
    }
}
