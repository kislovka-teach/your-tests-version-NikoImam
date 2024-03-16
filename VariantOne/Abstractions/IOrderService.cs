using Microsoft.AspNetCore.Authorization;
using VariantOne.Entities;

namespace VariantOne.Abstractions
{
    public interface IOrderService
    {
        public Task AddOrder(Models.RequestModels.Order order);

        [Authorize(Roles = "admin")]
        public Task SetStatus(int orderId, Status status);

        public Task<bool> PayOrder(int orderId, int value);
    }
}
