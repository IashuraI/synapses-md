using Md.Domain.Constants.Seeding;
using Md.Domain.Entities.Meals;
using Md.Domain.Entities.Products;
using Synapsess.Infrastructure.Interfaces;

namespace Md.Application.Seeding
{
    public class MealSeedingDataService
    {
        public readonly IRepository<Meal, Guid> _mealRepository;
        public readonly IRepository<Product, Guid> _productRepository;

        public MealSeedingDataService(IRepository<Meal, Guid> mealRepository, 
            IRepository<Product, Guid> productRepository)
        {
            _mealRepository = mealRepository;
            _productRepository = productRepository;
        }

        public async Task Seed()
        {
            List<Product> products = new() { Salmon(), Nori(), Cucumber(), Rice(), CreamCheese() };

            foreach (Product product in products)
            {
                await _productRepository.Create(product);
            }

            Meal meal = PhiladelphiaWithSalmon();
            meal.Products = products;

            await _mealRepository.Create(meal);
        }

        private Meal PhiladelphiaWithSalmon()
        {
            return new Meal()
            {
                Id = SeedingConstants.MealId,
                Name = "Philadelphia with salmon",
                Price = 310,
                CreatedUserId = UserConstants.DonnieBryantId,
                Category = new Category() { Name = "Sushi", CreatedUserId = UserConstants.DonnieBryantId } 
            };
        }

        private Product Salmon()
        {
            return new Product()
            {
                Name = "Salmon",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }

        private Product Nori()
        {
            return new Product()
            {
                Name = "Nori",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }

        private Product Cucumber()
        {
            return new Product()
            {
                Name = "Cucumber",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }

        private Product Rice()
        {
            return new Product()
            {
                Name = "Rice",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }

        private Product CreamCheese()
        {
            return new Product()
            {
                Name = "Cream cheese",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }
    }
}
