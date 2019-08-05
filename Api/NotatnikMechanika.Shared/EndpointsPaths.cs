using System;

namespace NotatnikMechanika.Shared
{
    public interface IPaths
    {
        string GetFullPath(string path);
    }
    public static class CRUDPaths
    {
        public const string GetPath = "{id}";
        public const string GetAllPath = "all";
        public const string CreatePath = "";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";
    }

    public class AccountPaths : IPaths
    {
        public const string Name = "api/account";
        public const string LoginPath = "login";
        public const string CreatePath = "create";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";

        public string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }
    public class CarPaths : IPaths
    {
        public const string Name = "api/car";

        public const string GetByCustomerPath = "byCustomer/{customerId}";

        public string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public class CustomerPaths : IPaths
    {
        public const string Name = "api/customer";

        public string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public class OrderPaths : IPaths
    {
        public const string Name = "api/order";
        public const string GetExtendedOrders = "extendedOrders";
        public const string GetArchivedExtendedOrders = "archivedExtendedOrders";

        public string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public class ServicePaths : IPaths
    {
        public const string Name = "api/service";

        public string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public class CommodityPaths : IPaths
    {
        public const string Name = "api/commodity";

        public string GetFullPath(string path)
        {
            return Name + "/" + path;
        }
    }

    public static class PathsHelper
    {
        public static IPaths GetPathsByModel<TModel>()
        {
            string name = typeof(TModel).Name.Replace("Model", "Paths");
            Type a = Type.GetType("NotatnikMechanika.Shared." + name);
            return Activator.CreateInstance(a) as IPaths;
        }
    }
}
