using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VariantOne.Abstractions;
using VariantOne.DbContexts;

namespace VariantOne.Services
{
    public class ProductRepository : IProductRepository
    {
        IMapper _mapper;
        ApplicationContext _applicationContext;
        public ProductRepository(IMapper mapper, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _applicationContext = applicationContext;
        }
        public async Task AddProduct(Models.RequestModels.Product product)
        {
            await _applicationContext.Products.AddAsync(_mapper.Map<Entities.Product>(product));
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<List<Models.ResultModels.Product>> GetAllProduct()
        {
            return _mapper.Map<List<Models.ResultModels.Product>>(await _applicationContext.Products.ToListAsync());
        }
    }
}
