using Microsoft.AspNetCore.Authorization;
using VariantTwo.Models.RequestModels;

namespace VariantTwo.Abstractions
{
    public interface ICarModelRepository
    {
        [Authorize(Roles = "admin")]
        public Task AddCarModel(CarModel carModel);
    }
}
