namespace Time_Management.Models
{
    public class Library
    {
        public double CalcSelfStudyHours(double credits, double hours, double weeks)
        {
            double study_hours = (credits * 10 / weeks) - hours;

            return study_hours;
        }

        // Calculates hours remaining for a module
        public double SelfStudyHoursRemaining(double hours, double hours_completed)
        {
            double hours_remaining = hours - hours_completed;

            if (hours_remaining < 0)
            {
                hours_remaining = 0;
            }

            return hours_remaining;
        }
    }
}
