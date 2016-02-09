namespace BuhtigIssueTracker.Utilities
{
    using System.Security.Cryptography;
    using System.Text;

    public static class HashUtilities
    {
        public static string HashPassword(string password)
        {
            string result = string.Join(string.Empty, SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password)));
            return result;
        }
    }
}
