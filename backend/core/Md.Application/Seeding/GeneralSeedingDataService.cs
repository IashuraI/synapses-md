using Md.Domain.Entities.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace Md.Application.Seeding
{
    public class GeneralSeedingDataService
    {
        private readonly IdentityDataMother _identitySeedingDataServie;
        private readonly MealDataMother _mealSeedingDataService;
        private readonly OrderDataMother _orderSeedingDataServicecs;
        private readonly IWebHostEnvironment _webHostingEnvironment;
        private readonly RoleManager<Role> _roleManager;

        public GeneralSeedingDataService(IdentityDataMother identitySeedingDataServie,
            MealDataMother mealSeedingDataService, OrderDataMother orderSeedingDataServicecs,
            IWebHostEnvironment webHostingEnvironment, RoleManager<Role> roleManager)
        {
            _identitySeedingDataServie = identitySeedingDataServie;
            _mealSeedingDataService = mealSeedingDataService;
            _orderSeedingDataServicecs = orderSeedingDataServicecs;
            _webHostingEnvironment = webHostingEnvironment;
            _roleManager = roleManager;
        }

        public async Task GeneralSeed()
        {
            if (!_webHostingEnvironment.IsProduction() && !_roleManager.Roles.Any())
            {
                await _identitySeedingDataServie.SeedIdentityData();
                await _mealSeedingDataService.SeedMealData();
                await _orderSeedingDataServicecs.SeedOrderData();
            }
        }
    }
}
