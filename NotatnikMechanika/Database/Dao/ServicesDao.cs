using System;
using System.Collections.Generic;
using System.Linq;

namespace NotatnikMechanika.Model.Dao
{
    public class ServicesDao
    {
        public void AddService(Service service)
        {
            using (var db = new MainEntities())
            {
                service.Id = db.Services.Count();
                db.Services.Add(service);
                db.SaveChangesAsync();
                db.Dispose();
            }
        }

        public void UpdateService(Service service)
        {
            throw (new NotImplementedException());
        }

        public void DeleteService(Service service)
        {
            throw (new NotImplementedException());
        }

        public List<Service> GetServices()
        {
            List<Service> services = new List<Service>();

            using (var db = new MainEntities())
            {

                services = (from st in db.Services select st).ToList();
            }

            return services;
        }
    }
}