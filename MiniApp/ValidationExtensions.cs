namespace MiniApp
{
    public static class ValidationExtensions
    {
        public static bool IsValidName(this string name)
        {
            return !string.IsNullOrWhiteSpace(name) &&
                   name.Length >= 3 &&
                   !name.Contains(" ") &&
                   char.IsUpper(name[0]);
        }

        public static bool IsValidSurname(this string surname)
        {
            return IsValidName(surname);
        }

        public static bool IsValidClassName(this string className)
        {
            return className.Length == 3 &&
                   char.IsUpper(className[0]) &&
                   char.IsUpper(className[1]) &&
                   char.IsDigit(className[2]);
        }
    }
}
