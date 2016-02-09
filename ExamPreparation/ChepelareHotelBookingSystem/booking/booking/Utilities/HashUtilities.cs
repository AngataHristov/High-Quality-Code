namespace HotelBookingSystem.Utilities
{
    using System.Security.Cryptography;
    using System.Text;

    public class HashUtilities
    {
        public static string GetSha256Hash(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var hashedOutput = new StringBuilder();
            foreach (byte @byte in new SHA256Managed().ComputeHash(bytes))
            {
                hashedOutput.AppendFormat("{0:x2}", @byte);
            }

            return hashedOutput.ToString();
        }
    }
}
