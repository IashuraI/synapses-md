using Md.Domain.Entities.Meal;
using Md.Domain.Entities.Products;
using Synapsess.Infrastructure.Interfaces;

namespace Md.Application.Seeding
{
    public class MealSeedingDataService : ISeedingService
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

            foreach(Product product in meal.Products)
            {
                product.Id = products.First(pr => pr.Name == pr.Name).Id;
            }

            await _mealRepository.Create(meal);
        }

        public Meal PhiladelphiaWithSalmon()
        {
            return new Meal()
            {
                Name = "Philadelphia with salmon",
                Price = 310,
                Products = new List<Product>() { new Product { Name = Salmon().Name }, new Product { Name = CreamCheese().Name },
                    new Product { Name = Cucumber().Name }, new Product { Name = Rice().Name }, new Product { Name = Nori().Name }, }
            };
        }

        private Product Salmon()
        {
            return new Product()
            {
                Name = "Salmon",
            };
        }

        private Product Nori()
        {
            return new Product()
            {
                Name = "Nori",
            };
        }

        private Product Cucumber()
        {
            return new Product()
            {
                Name = "Cucumber",
            };
        }

        private Product Rice()
        {
            return new Product()
            {
                Name = "Rice",
            };
        }

        private Product CreamCheese()
        {
            return new Product()
            {
                Name = "Cream cheese",
            };
        }
    }
}
