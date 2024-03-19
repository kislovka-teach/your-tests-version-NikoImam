using AutoMapper;
using VariantTwo.Abstractions;
using VariantTwo.DbContexts;
using VariantTwo.Models.RequestModels;

namespace VariantTwo.Services
{
    public class CarRepository : ICarRepository
    {
        IMapper _mapper;
        ApplicationContext _applicationContext;
        public CarRepository(IMapper mapper, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _applicationContext = applicationContext;
        }

        public async Task AddCar(Car car)
        {
            await _applicationContext.Cars.AddAsync(_mapper.Map<Entities.Car>(car));
            await _applicationContext.SaveChangesAsync();
        }
    }
}
