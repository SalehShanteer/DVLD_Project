using DVLD_DataAccess;
using Global_Variables_Data;

namespace DVLD_Business
{
    public static class clsSettings
    {

        // Manage People
        public const short peopleListRowsPerPage = clsSettingsData.peopleListRowsPerPage;


        // Permissions
        public static bool CheckPermission(int Permission)
        {
            int Permissions = clsUserSetting.GetCurrentUserPermissions();

            return ((Permissions & Permission) == Permission) || (Permissions == -1);
        }

        public enum enPeoplePermissions
        {
            Read = 1,
            AddUpdate = 2,
            Delete = 4
        }

        public enum enLocalLicenseApplicationPermissions
        {
            Read = 8,
            AddUpdate = 16,
            Delete = 32
        }

        public enum enLicensePermissions
        {
            ReadLocal = 64,
            ReadInternational = 128,
            IssueLocal = 256,
            IssueInternational = 512
        }

        public enum enTestPermissions
        {
            Read = 1024,
            AddUpdate = 2048,
            TakeTest = 4096,
            UpdateTestInfo = 8192
        }

        public enum enUserPermissions
        {
            Read = 16384,
            AddUpdate = 32768,
            Delete = 65536
        }

        public enum enDriverPermissions
        {
            Read = 131072,
        }

        public enum enLicenseOperationPermissions
        {
            Renew = 262144,
            Replace = 524288,
            Detain = 1048576,
            Release = 2097152,
            Read = 4194304
        }

    }
}
