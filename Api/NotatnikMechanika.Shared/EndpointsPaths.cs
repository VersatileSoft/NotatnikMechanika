namespace NotatnikMechanika.Shared
{
    public static class CRUDPaths
    {
        public const string GetPath = "{id}";
        public const string GetAllPath = "all";
        public const string CreatePath = "";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";
    }

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

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public static class CustomerPaths
    {
        public const string Name = "api/customer";

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public static class OrderPaths
    {
        public const string Name = "api/order";

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public static class ServicePaths
    {
        public const string Name = "api/service";

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public static class CommodityPaths
    {
        public const string Name = "api/commodity";

        public static string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }
}
