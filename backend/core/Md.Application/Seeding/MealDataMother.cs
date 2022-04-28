using Md.Domain.Constants.Seeding;
using Md.Domain.Entities.Meals;
using Md.Domain.Entities.Products;
using Synapsess.Infrastructure.Interfaces;

namespace Md.Application.Seeding
{
    public class MealDataMother
    {
        public readonly IRepository<Meal, Guid> _mealRepository;
        public readonly IRepository<Product, Guid> _productRepository;

        public MealDataMother(IRepository<Meal, Guid> mealRepository, 
            IRepository<Product, Guid> productRepository)
        {
            _mealRepository = mealRepository;
            _productRepository = productRepository;
        }

        public async Task SeedMealData()
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

        public Meal PhiladelphiaWithSalmon()
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

        public Product Salmon()
        {
            return new Product()
            {
                Name = "Salmon",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }

        public Product Nori()
        {
            return new Product()
            {
                Name = "Nori",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }

        public Product Cucumber()
        {
            return new Product()
            {
                Name = "Cucumber",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }

        public Product Rice()
        {
            return new Product()
            {
                Name = "Rice",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }

        public Product CreamCheese()
        {
            return new Product()
            {
                Name = "Cream cheese",
                CreatedUserId = UserConstants.DonnieBryantId
            };
        }
    }
}
