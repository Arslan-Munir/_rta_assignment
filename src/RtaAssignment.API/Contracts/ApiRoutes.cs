namespace RtaAssignment.API.Contracts
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version + "/";

        //  api/v1/
        public static class Auth
        {
            private const string Page = "auth/";

            public const string Login = Base + Page;
            public const string GetAll = Base + "auths";
            public const string Get = Base + Page;
            public const string Update = Base + Page + "{id}";
            public const string Delete = Base + Page + "{id}";
        }
        
        public static class EmployeeType
        {
            private const string Page = "employee-type/";

            public const string GetAll = Base + Page + "all";
        }

        public static class Employee
        {
            private const string Page = "employee/";

            public const string Add = Base + Page;
            public const string Get = Base + Page + "{id}";
            public const string GetAll = Base + Page + "all";
            public const string Update = Base + Page + "{id}";
            public const string UploadPhoto = Base + Page + "{id}/upload-photo";
            public const string Photo = Base + Page + "photo/{id}";
            public const string DeletePhoto = Base + Page + "photo/{photoId}";
        }
    }
}