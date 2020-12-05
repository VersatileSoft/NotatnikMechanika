using AutoMapper;
using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository.Interfaces;
using NotatnikMechanika.Api.Service.Interfaces;
using NotatnikMechanika.Service.Services.Base;
using NotatnikMechanika.Shared.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Api.Service.Services
{
    public class CarService : ServiceBase<CarModel, Car>, ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;
        public CarService(ICarRepository carRepository, ICustomerRepository customerRepository, IMapper mapper) : base(carRepository, mapper)
        {
            _carRepository = carRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Response<IEnumerable<CarModel>>> ByCustomerAsync(string userId, int customerId)
        {
            if (!await _customerRepository.CheckIfUserMatch(userId, customerId))
            {
                return FailureResponse<IEnumerable<CarModel>>(ResponseType.Failure, new List<string> {NotAllowedError});
            }

            return SuccessResponse(await _carRepository.ByCustomerAsync(customerId));
        }
    }
}
