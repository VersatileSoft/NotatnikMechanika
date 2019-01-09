using System;
using System.Collections.Generic;
using System.Linq;

namespace NotatnikMechanika.Model.Dao
{
    public class CustomersDao
    {
        public void AddCustomer(Customer customer)
        {
            using (var db = new MainEntities())
            {
                customer.Id = db.Customers.Count();
                db.Customers.Add(customer);
                db.SaveChangesAsync();
                db.Dispose();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            throw (new NotImplementedException());
        }

        public void DeleteCustomer(Customer customer)
        {
            throw (new NotImplementedException());
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (var db = new MainEntities())
            {

                customers = (from st in db.Customers select st).ToList();
            }

            return customers;
        }
    }
}