using Md.Domain.Entities.Products;
using Synapsess.Infrastructure.Interfaces;

namespace Md.Application.Seeding
{
    public class ProductSeedingDataService : ISeedingService
    {

        public ProductSeedingDataService()
        {
            _productRepository = productRepository;
        }

 
    }
}
