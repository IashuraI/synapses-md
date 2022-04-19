using Md.Domain.Constants.Seeding;
using Md.Domain.Entities.Location;
using Md.Domain.Entities.Orders;
using Synapsess.Infrastructure.Interfaces;

namespace Md.Application.Seeding
{
    public class OrderSeedingDataServicecs
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

        private Order SushiOrder()
        {
            return new Order
            {
                Id = SeedingConstants.OrderId,
                CustomerId = SeedingConstants.EllenWilkesId,
                OpenTime = new DateTime(2022, 04, 15, 19, 54, 41, DateTimeKind.Utc),
                OrderMeals = new List<OrderMeal>()
                {
                    new OrderMeal
                    {
                        MealId = SeedingConstants.MealId,
                        Amount = 1,
                        CreatedUserId = UserConstants.EllenWilkesId
                    }
                },
                PaymentMethod = Domain.Enums.PaymentMethod.Online,
                CreatedUserId = UserConstants.MayaBernalId,
                AddressTo = AddressTo(),
                AddressFrom = AddressFrom(),
            };
        }

        private Address AddressTo()
        {
            return new Address
            {
                AddressLine = "Level 1/80 Pyrmont St",
                City = "Pyrmont",
                State = "NSW",
                Zip = "2009",
                Lat = (decimal)-33.866489,
                Lng = (decimal)151.1958561,
                GooglePlaceId = "ChIJ1-v38TauEmsRCk28fG54adI",
                CreatedUserId = UserConstants.MayaBernalId
            };
        }

        private Address AddressFrom()
        {
            return new Address
            {
                AddressLine = "80 Pyrmont St",
                City = "Pyrmont",
                State = "NSW",
                Zip = "2009",
                Lat = (decimal)-33.866489,
                Lng = (decimal)151.1958561,
                GooglePlaceId = "ChIJ0V4pqzeuEmsR0bq8RT7RTkM",
                CreatedUserId = UserConstants.MayaBernalId
            };
        }
    }
}
