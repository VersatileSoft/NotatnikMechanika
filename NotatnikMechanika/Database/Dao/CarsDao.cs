using System;
using System.Collections.Generic;
using System.Linq;

namespace NotatnikMechanika.Model.Dao
{
    public class CarsDao
    {
        public void AddCar(Car car)
        {
            using (var db = new MainEntities())
            {
                car.Id = db.Cars.Count();
                db.Cars.Add(car);
                db.SaveChangesAsync();
                db.Dispose();
            }
        }

        public void UpdateCar(Car car)
        {
            throw (new NotImplementedException());
        }

        public void DeleteCar(Car car)
        {
            throw (new NotImplementedException());
        }

        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();

            using (var db = new MainEntities())
            {

                cars = (from st in db.Cars select st).ToList();
            }

            return cars;
        }

    }
}