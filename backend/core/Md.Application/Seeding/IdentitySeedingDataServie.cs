﻿using Md.Domain.Constants.Identity;
using Md.Domain.Constants.Seeding;
using Md.Domain.Entities.Customers;
using Md.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Synapsess.Infrastructure.Interfaces;

namespace Md.Application.Seeding
{
    public class IdentitySeedingDataServie
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Customer, Guid> _customerRepository;

        public IdentitySeedingDataServie(RoleManager<Role> roleManager, UserManager<User> userManager,
            IRepository<Customer, Guid> customerRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _customerRepository = customerRepository;
        }

        public async Task Seed()
        {
            await _roleManager.CreateAsync(new Role() { Name = RoleConstants.Admin });
            await _roleManager.CreateAsync(new Role() { Name = RoleConstants.DeliveryMan });
            await _roleManager.CreateAsync(new Role() { Name = RoleConstants.Operator });
            await _roleManager.CreateAsync(new Role() { Name = RoleConstants.Customer });

            User donnieBryant = DonnieBryant();
            await _userManager.CreateAsync(donnieBryant, "Qwe123!");
            await _userManager.AddToRoleAsync(donnieBryant, RoleConstants.Admin);

            User mayaBernal = MayaBernal();
            await _userManager.CreateAsync(mayaBernal, "Qwe123!");
            await _userManager.AddToRoleAsync(mayaBernal, RoleConstants.Operator);

            User samadSaltert = SamadSaltert();
            await _userManager.CreateAsync(samadSaltert, "Qwe123!");
            await _userManager.AddToRoleAsync(samadSaltert, RoleConstants.DeliveryMan);

            User ellenWilkes = EllenWilkes();
            await _userManager.CreateAsync(ellenWilkes, "Qwe123!");
            await _userManager.AddToRoleAsync(ellenWilkes, RoleConstants.Customer);

            await _customerRepository.Create(EllenWilkesCustomer());
        }

        private User DonnieBryant()
        {
            return new() { Id = UserConstants.DonnieBryantId, UserName = "DonnieBryant"};
        }

        private User MayaBernal()
        {
            return new() { Id = UserConstants.MayaBernalId, UserName = "MayaBernal" };
        }

        private User SamadSaltert()
        {
            return new() { Id = UserConstants.SamadSaltertId, UserName = "SamadSaltert" };
        }

        private User EllenWilkes()
        {
            return new() { Id = UserConstants.EllenWilkesId, UserName = "EllenWilkes" };
        }

        private Customer EllenWilkesCustomer()
        {
            return new()
            {
                Id = SeedingConstants.EllenWilkesId,
                FirstName = "Ellen",
                LastName = "Wilkes",
                CreatedUserId = UserConstants.EllenWilkesId
            };
        }
    }
}
