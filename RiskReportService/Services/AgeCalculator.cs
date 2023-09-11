using RiskReportService.Contracts;

namespace RiskReportService.Services
{
    public class AgeCalculator : IAgeCalculator
    {
        public int CalculateAge(DateTime dateOfBirth)
        {
            int YearOfBirth = dateOfBirth.Year;
            int CurrentYear = DateTime.Now.Year;
            int CurrentMonth = DateTime.Now.Month;
            int CurrentDay = DateTime.Now.Day;
            int Age;

            // If DateOfBirth occurs after the current day, set Age to 0.
            if (dateOfBirth.Year > CurrentYear || (dateOfBirth.Year == CurrentYear && dateOfBirth.Month > CurrentMonth)
                || (dateOfBirth.Year == CurrentYear && dateOfBirth.Month == CurrentMonth && dateOfBirth.Day > CurrentDay))
            {
                Age = 0;
            }

            else if (dateOfBirth.Month > DateTime.Now.Month || (dateOfBirth.Month == DateTime.Now.Month && dateOfBirth.Day > DateTime.Now.Day))
            {
                Age = CurrentYear - YearOfBirth - 1;
            }
            else
            {
                Age = CurrentYear - YearOfBirth;
            }

            Console.WriteLine("Patient's age is " + Age + " years.");
            return Age;
        }
    }
}
