namespace VariantOne.Abstractions
{
    public interface IProductRepository
    {
        public Task AddProduct(Models.RequestModels.Product product);

        public Task<List<Models.ResultModels.Product>> GetAllProduct();
    }
}
