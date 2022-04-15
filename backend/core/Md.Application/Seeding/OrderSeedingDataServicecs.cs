using Md.Domain.Constants.Seeding;
using Md.Domain.Entities.Orders;
using Synapsess.Infrastructure.Interfaces;

namespace Md.Application.Seeding
{
    public class OrderSeedingDataServicecs : ISeedingService
    {
        private readonly IRepository<Order, Guid> _orderRepository;

        public OrderSeedingDataServicecs(IRepository<Order, Guid> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Seed()
        {
            await _orderRepository.Create(SushiOrder());
        }

        public Order SushiOrder()
        {
            return new Order
            {
                CustomerId = UserConstants.EllenWilkesId,
                OpenTime = new DateTime(2022, 04, 15, 19, 54, 41, DateTimeKind.Utc),
                OrderMeals = new List<OrderMeal>()
                {
                    new OrderMeal
                    {
                        MealId = SeedingConstants.MealId,
                        Amount = 1
                    }
                },
                PaymentMethod = Domain.Enums.PaymentMethod.Online,
                CreatedUserId = UserConstants.MayaBernalId,
            };
        }
    }
}
