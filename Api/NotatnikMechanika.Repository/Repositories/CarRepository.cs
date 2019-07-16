using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;
using NotatnikMechanika.Repository.Interfaces;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotatnikMechanika.Repository.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly NotatnikMechanikaDbContext _dbContext;
        public CarRepository(NotatnikMechanikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfUserMatch(int userId, int carId)
        {
            return await _dbContext.Cars.Where(a => a.UserId == userId).Where(a => a.Id == carId).AnyAsync();
        }

        public async Task CreateAsync(int userId, CarModel value)
        {
            await _dbContext.Cars.AddAsync(new Car
            {
                Brand = value.Brand,
                Engine = value.Engine,
                Model = value.Model,
                Plate = value.Plate,
                Power = value.Power,
                UserId = userId,
                CustomerId = value.CustomerId,
                Vin = value.Vin
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int carId)
        {
            _dbContext.Cars.Remove(await _dbContext.Cars.Where(a => a.Id == carId).FirstOrDefaultAsync());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CarModel> GetCarAsync(int carId)
        {
            return await _dbContext.Cars.Where(a => a.Id == carId).Select(value => new CarModel
            {
                Brand = value.Brand,
                Engine = value.Engine,
                Model = value.Model,
                Plate = value.Plate,
                Power = value.Power,
                CustomerId = value.CustomerId,
                Vin = value.Vin
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CarModel>> GetCarsAsync(int userId)
        {
            return await _dbContext.Cars.Where(a => a.UserId == userId).Select(value => new CarModel
            {
                Brand = value.Brand,
                Engine = value.Engine,
                Model = value.Model,
                Plate = value.Plate,
                Power = value.Power,
                CustomerId = value.CustomerId,
                Vin = value.Vin
            }).ToListAsync();
        }

        public async Task UpdateAsync(int carId, CarModel value)
        {
            Car car = await _dbContext.Cars.Where(a => a.Id == carId).FirstOrDefaultAsync();

            car.Brand = value.Brand;
            car.Engine = value.Engine;
            car.Model = value.Model;
            car.Plate = value.Plate;
            car.Power = value.Power;
            car.CustomerId = value.CustomerId;
            car.Vin = value.Vin;

            _dbContext.Cars.Update(car);
            await _dbContext.SaveChangesAsync();
        }
    }
}
