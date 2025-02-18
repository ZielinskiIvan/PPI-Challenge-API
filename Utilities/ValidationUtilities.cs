namespace PPI_Challenge_API.Utilities
{
    public static class ValidationUtilities
    {
        public static string NonEmptyMessage = "The field {PropertyName} is required.";
        public static string UpperCaseMessage = "The field {PropertyName} must have an upper case character.";
        public static string DigitMessage = "The field {PropertyName} must have at least one digit (0-9).";
        public static string NotAlphanumericMessage = "The field {PropertyName} must have at least one non alphanumeric character.";
        public static string MaximumLengthMessage = "The field {PropertyName} should be less than {MaxLength} characters.";
        public static string MinimumLengthMessage = "The field {PropertyName} should be more than {ComparisonValue} characters.";
        public static string FirstLetterIsUpperCaseMessage = "The field {PropertyName} should start with uppercase.";
        public static string EmailAddressMessage = "The field {PropertyName} is not a valid email address.";

        #region Password
        public static string PasswordEqualsToRepeatedPassword = "The field {PropertyName} must be the same to {PropertyName2}";
        #endregion
        public static string GreaterThanDate(DateTime value) => "The field {PropertyName} should be greater than " + value.ToString("yyyy-MM-dd");

        #region Operation 
        public static string CaracterOperationValidValues = "The field {PropertyName} must be 'C' (Purchase) o 'V' (Sale)";
        #endregion
        public static bool FirstLetterIsUppercase(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            var firstLetter = value[0].ToString();
            return firstLetter == firstLetter.ToUpper();
        }
    }
}
