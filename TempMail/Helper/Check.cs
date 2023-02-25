namespace TempMail.Helper
{
    internal class Check
    {
        public static void IsValid(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Param cannot be null", paramName);
            }
        }

        public static void IsValid(int minValue, int maxValue)
        {
            if (minValue <= 0 || maxValue <= 0)
            {
                throw new ArgumentException("Max/Min length cannot be zero");
            }
            if (maxValue < minValue)
            {
                throw new ArgumentException("Max length cannot be lower than min length");
            }
        }
    }
}