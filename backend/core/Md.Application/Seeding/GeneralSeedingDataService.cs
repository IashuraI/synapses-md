namespace Md.Application.Seeding
{
    public class GeneralSeedingDataService
    {
        private readonly IdentitySeedingDataServie _identitySeedingDataServie;
        private readonly MealSeedingDataService _mealSeedingDataService;
        private readonly OrderSeedingDataServicecs _orderSeedingDataServicecs;

        public GeneralSeedingDataService(IdentitySeedingDataServie identitySeedingDataServie, 
            MealSeedingDataService mealSeedingDataService, OrderSeedingDataServicecs orderSeedingDataServicecs)
        {
            _identitySeedingDataServie = identitySeedingDataServie;
            _mealSeedingDataService = mealSeedingDataService;
            _orderSeedingDataServicecs = orderSeedingDataServicecs;
        }

        public async Task GeneralSeed()
        {
            await _identitySeedingDataServie.Seed();
            await _mealSeedingDataService.Seed();
            await _orderSeedingDataServicecs.Seed();
        }
    }
}
