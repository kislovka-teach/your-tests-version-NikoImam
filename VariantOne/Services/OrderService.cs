using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VariantOne.Abstractions;
using VariantOne.DbContexts;
using VariantOne.Entities;

namespace VariantOne.Services
{
    public class OrderService : IOrderService
    {
        IMapper _mapper;
        ApplicationContext _applicationContext;

        public OrderService(IMapper mapper, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _applicationContext = applicationContext;
        }
        public async Task AddOrder(Models.RequestModels.Order order)
        {
            var ord = _mapper.Map<Order>(order);

            await _applicationContext.Orders.AddAsync(ord);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<bool> PayOrder(int orderId, int value)
        {
            var order = await _applicationContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            if (order is null || order.TotalPrice > value) return false;

            await SetStatus(orderId, Status.AwaitReceipt);

            return true;
        }

        public async Task SetStatus(int orderId, Status status)
        {
            (await _applicationContext.Orders.FirstAsync(o => o.Id == orderId)).Status = status;
            await _applicationContext.SaveChangesAsync();
        }
    }
}
