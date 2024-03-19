using AutoMapper;
using VariantTwo.Abstractions;
using VariantTwo.DbContexts;
using VariantTwo.Models.RequestModels;

namespace VariantTwo.Services
{
    public class CarModelRepository : ICarModelRepository
    {
        IMapper _mapper;
        ApplicationContext _applicationContext;
        public CarModelRepository(IMapper mapper, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _applicationContext = applicationContext;
        }

        public async Task AddCarModel(CarModel carModel)
        {
            await _applicationContext.CarModels.AddAsync(_mapper.Map<Entities.CarModel>(carModel));
            await _applicationContext.SaveChangesAsync();
        }
    }
}
