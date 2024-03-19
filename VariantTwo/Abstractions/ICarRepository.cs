using Microsoft.AspNetCore.Authorization;
using VariantTwo.Models.RequestModels;

namespace VariantTwo.Abstractions
{
    public interface ICarRepository
    {
        public Task AddCar(Car car);
    }
}
