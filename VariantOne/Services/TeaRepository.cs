using AutoMapper;
using VariantOne.Abstractions;
using VariantOne.DbContexts;
using VariantOne.Models.RequestModels;

namespace VariantOne.Services
{
    public class TeaRepository : ITeaRepository
    {
        IMapper _mapper;
        ApplicationContext _applicationContext;
        public TeaRepository(IMapper mapper, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _applicationContext = applicationContext;
        }

        public async Task AddTea(Tea tea)
        {
            await _applicationContext.Teas.AddAsync(_mapper.Map<Entities.Tea>(tea));
            await _applicationContext.SaveChangesAsync();
        }
    }
}
