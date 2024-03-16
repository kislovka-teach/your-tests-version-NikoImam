using VariantOne.Entities;

namespace VariantOne.Abstractions
{
    public interface ITeaRepository
    {
        public Task AddTea(Models.RequestModels.Tea tea);
    }
}
