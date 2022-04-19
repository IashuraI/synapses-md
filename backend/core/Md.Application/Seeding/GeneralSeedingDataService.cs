using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Md.Application.Seeding
{
    public class GeneralSeedingDataService
    {
        private readonly IdentitySeedingDataServie _identitySeedingDataServie;
        private readonly MealSeedingDataService _mealSeedingDataService;
        private readonly OrderSeedingDataServicecs _orderSeedingDataServicecs;
        private IWebHostEnvironment _webHostingEnvironment;

        public GeneralSeedingDataService(IdentitySeedingDataServie identitySeedingDataServie, 
            MealSeedingDataService mealSeedingDataService, OrderSeedingDataServicecs orderSeedingDataServicecs,
            IWebHostEnvironment webHostingEnvironment)
        {
            _identitySeedingDataServie = identitySeedingDataServie;
            _mealSeedingDataService = mealSeedingDataService;
            _orderSeedingDataServicecs = orderSeedingDataServicecs;
            _webHostingEnvironment = webHostingEnvironment;
        }

        public async Task GeneralSeed()
        {
            if (!_webHostingEnvironment.IsProduction())
            {
                await _identitySeedingDataServie.Seed();
                await _mealSeedingDataService.Seed();
                await _orderSeedingDataServicecs.Seed();
            }
        }
    }
}
