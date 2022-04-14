using Md.Domain.Constants.Identity;
using Md.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Md.Application.Seeding
{
    public class IdentitySeedingDataServie : ISeedingService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public IdentitySeedingDataServie(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            await _roleManager.CreateAsync(new Role() { Name = RoleConstants.Admin });
            await _roleManager.CreateAsync(new Role() { Name = RoleConstants.DeliveryMan });
            await _roleManager.CreateAsync(new Role() { Name = RoleConstants.Operator });
            await _roleManager.CreateAsync(new Role() { Name = RoleConstants.Customer });

            User donnieBryant = DonnieBryant();
            await _userManager.CreateAsync(donnieBryant);
            await _userManager.AddToRoleAsync(donnieBryant, RoleConstants.Admin);

            User mayaBernal = MayaBernal();
            await _userManager.CreateAsync(mayaBernal);
            await _userManager.AddToRoleAsync(mayaBernal, RoleConstants.Operator);

            User samadSaltert = SamadSaltert();
            await _userManager.CreateAsync(samadSaltert);
            await _userManager.AddToRoleAsync(samadSaltert, RoleConstants.DeliveryMan);

            User ellenWilkes = EllenWilkes();
            await _userManager.CreateAsync(ellenWilkes);
            await _userManager.AddToRoleAsync(ellenWilkes, RoleConstants.Customer);
        }

        private User DonnieBryant()
        {
            return new() { Id = UserConstants.DonnieBryantId, UserName = "Donnie Bryant" };
        }

        private User MayaBernal()
        {
            return new() { Id = UserConstants.MayaBernalId, UserName = "Maya Bernal" };
        }

        private User SamadSaltert()
        {
            return new() { Id = UserConstants.SamadSaltertId, UserName = "Samad Saltert" };
        }

        private User EllenWilkes()
        {
            return new() { Id = UserConstants.EllenWilkesId, UserName = "Ellen Wilkes" };
        }
    }
}
