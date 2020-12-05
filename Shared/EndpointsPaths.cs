namespace NotatnikMechanika.Shared
{
    public static class CrudPaths
    {
        
        public const string ByIdPath = "{id}";
        public const string AllPath = "all";
        public const string CreatePath = "";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";

        public static string ById<TModel>(int id)
        {
            return CrudPathByModel<TModel>(ByIdPath).Replace("{id}", id.ToString());
        }

        public static string All<TModel>()
        {
            return CrudPathByModel<TModel>(AllPath);
        }

        public static string Create<TModel>()
        {
            return CrudPathByModel<TModel>(CreatePath);
        }

        public static string Update<TModel>(int id)
        {
            return CrudPathByModel<TModel>(UpdatePath).Replace("{id}", id.ToString());
        }

        public static string Delete<TModel>(int id)
        {
            return CrudPathByModel<TModel>(DeletePath).Replace("{id}", id.ToString());
        }

        private static string CrudPathByModel<TModel>(string path)
        {
            string controllerName = "api/" + typeof(TModel).Name.Replace("Model", "").ToLower();
            return controllerName + "/" + path;
        }
    }

    public static class AccountPaths
    {
        public const string Name = "api/account";
        public const string LoginPath = "login";
        public const string RegisterPath = "create";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";

        public static string Login()
        {
            return Name + "/" + LoginPath;
        }

        public static string Register()
        {
            return Name + "/" + RegisterPath;
        }

        public static string Update(int id)
        {
            return Name + "/" + UpdatePath.Replace("{id}", id.ToString());
        }

        public static string Delete(int id)
        {
            return Name + "/" + DeletePath.Replace("{id}", id.ToString());
        }
    }
    public static class CarPaths
    {
        public const string Name = "api/car";
        public const string ByCustomerPath = "byCustomer/{customerId}";

        public static string ByCustomer(int customerId)
        {
            return Name + "/" + ByCustomerPath.Replace("{customerId}", customerId.ToString());
        }
    }

    public static class CustomerPaths
    {
        public const string Name = "api/customer";
    }

    public static class OrderPaths
    {
        public const string Name = "api/order";
        public const string ExtendedOrdersPath = "extendedOrders/{archived}";
        public const string ExtendedOrderPath = "extendedOrder/{orderId}";
        public const string AddServiceToOrderPath = "addService/{orderId}/{serviceId}";
        public const string AddCommodityToOrderPath = "addCommodity/{orderId}/{commodityId}";
        public const string DeleteServiceFromOrderPath = "deleteService/{orderId}/{serviceId}";
        public const string DeleteCommodityFromOrderPath = "deleteCommodity/{orderId}/{commodityId}";

        public static string Extended(bool archived)
        {
            return Name + "/" + ExtendedOrdersPath.Replace("{archived}", archived.ToString());
        }

        public static string Extended(int orderId)
        {
            return Name + "/" + ExtendedOrderPath.Replace("{orderId}", orderId.ToString());
        }

        public static string AddService(int orderId, int serviceId)
        {
            return Name + "/" + AddServiceToOrderPath.
Replace("{orderId}", orderId.ToString()).
Replace("{serviceId}", serviceId.ToString());
        }

        public static string AddCommodity(int orderId, int commodityId)
        {
            return Name + "/" + AddCommodityToOrderPath.
Replace("{orderId}", orderId.ToString()).
Replace("{commodityId}", commodityId.ToString());
        }

        public static string DeleteService(int orderId, int serviceId)
        {
            return Name + "/" + DeleteServiceFromOrderPath.
Replace("{orderId}", orderId.ToString()).
Replace("{serviceId}", serviceId.ToString());
        }

        public static string DeleteCommodity(int orderId, int commodityId)
        {
            return Name + "/" + DeleteCommodityFromOrderPath.
Replace("{orderId}", orderId.ToString()).
Replace("{commodityId}", commodityId.ToString());
        }
    }

    public static class ServicePaths
    {   
        public const string Name = "api/service";
        public const string AllPath = "all/{orderId}";
        public const string ByOrderPath = "byOrder/{orderId}";

        public static string All(int orderId)
        {
            return Name + "/" + AllPath.Replace("{orderId}", orderId.ToString());
        }

        public static string ByOrder(int orderId)
        {
            return Name + "/" + ByOrderPath.Replace("{orderId}", orderId.ToString());
        }
    }

    public static class CommodityPaths
    {
        public const string Name = "api/commodity";
        public const string AllPath = "all/{orderId}";
        public const string ByOrderPath = "byOrder/{orderId}";

        public static string All(int orderId)
        {
            return Name + "/" + AllPath.Replace("{orderId}", orderId.ToString());
        }

        public static string ByOrder(int orderId)
        {
            return Name + "/" + ByOrderPath.Replace("{orderId}", orderId.ToString());
        }
    }
}
