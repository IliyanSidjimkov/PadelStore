

namespace PadelStore.GCommon
{
    public static class ExceptionMessages
    {
        public const string RoleSeedingExceptionMessage = "There was an error while trying to seed the role {0}! Please see inner exception for details!";
        public const string AdminUserSeedingEmailNotFoundMessage = "Admin email not found in configuration.";
        public const string AdminUserSeedingPasswordNotFoundMessage = "Admin password not found in configuration.";
        public const string AdminUserSeedingExceptionMessage = "There was an error while trying to seed the admin user! Please see inner exception for details!";
    }
}
