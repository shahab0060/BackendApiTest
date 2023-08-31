namespace BackendApiTest.Core.Extensions.BasicExtensions
{
    public static class ValidationExtensions
    {
        public static bool IsEmailValid(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPhoneNumberValid(this string? phoneNumber)
       => phoneNumber != null && phoneNumber.Length == 11 && phoneNumber.StartsWith("09") && phoneNumber.IsNumber() ? true : false;

        public static bool IsNumber(this string format)
        {
            string allowableNumbers = "1234567890";

            foreach (char c in format)
            {
                // This is using String.Contains for .NET 2 compat.,
                //   hence the requirement for ToString()
                if (!allowableNumbers.Contains(c.ToString()))
                    return false;
            }

            return true;
        }
    }
}
