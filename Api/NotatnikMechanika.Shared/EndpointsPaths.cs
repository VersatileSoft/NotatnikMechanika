namespace NotatnikMechanika.Shared
{
    public static class AccountPaths
    {
        public const string Name = "api/account";
        public const string LoginPath = "login";
        public const string CreatePath = "create";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }
    public static class CarPaths
    {
        public const string Name = "api/car";

        public const string GetCarPath = "{id}";
        public const string GetCarsPath = "all";
        public const string CreatePath = "";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public static class CustomerPaths
    {
        public const string Name = "api/customer";

        public const string GetCustomerPath = "{id}";
        public const string GetCustomersPath = "all";
        public const string CreatePath = "";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public static class OrderPaths
    {
        public const string Name = "api/order";

        public const string GetOrderPath = "{id}";
        public const string GetOrdersPath = "all";
        public const string CreatePath = "";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }
}
