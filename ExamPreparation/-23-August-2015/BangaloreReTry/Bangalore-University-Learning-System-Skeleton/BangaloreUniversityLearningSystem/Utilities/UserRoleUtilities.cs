namespace BangaloreUniversityLearningSystem.Utilities
{
    using Enumerations;

    public static class UserRoleUtilities
    {
        public static bool IsInRole(this User user, Role role)
        {
            return user != null && user.Role == role;
        }
    }
}
