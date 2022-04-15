namespace Md.Application.Seeding
{
    public class GeneralSeedingDataService
    {
        private readonly IEnumerable<ISeedingService> _seedingServices;

        public GeneralSeedingDataService(IEnumerable<ISeedingService> seedingServices)
        {
            _seedingServices = seedingServices;
        }

        public async Task GeneralSeed()
        {
            foreach (ISeedingService service in _seedingServices)
            {
                await service.Seed();
            }
        }
    }
}
