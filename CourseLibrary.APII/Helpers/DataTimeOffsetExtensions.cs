namespace CourseLibrary.APII.Helpers
{
    public static class DataTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
            var currentDate = DateTime.UtcNow;

            int age = currentDate.Year - dateTimeOffset.Year;

            if(currentDate < dateTimeOffset.AddYears(age)) 
            {
                age--;
            }
            return age;
        }
    }
}
