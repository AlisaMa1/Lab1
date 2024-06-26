using OnlineBookStoreApp.Data;
using OnlineBookStoreApp.Helpers;
using OnlineBookStoreApp.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookStoreApp.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Konteksti _konteksti;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            Konteksti konteksti)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _konteksti = konteksti;
        }

        public void Initialize()
        {
            try
            {
                if (_konteksti.Database.GetPendingMigrations().Count() > 0)
                {
                    _konteksti.Database.Migrate();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (!_roleManager.RoleExistsAsync(Sd.RoliAdmin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Sd.RoliAdmin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Sd.RoliPunetor)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Sd.RolePerdorusIndividual)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Sd.RolePerdorusKompani)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new Perdorusi()
                {
                    UserName = "alisa@gmail.com",
                    Email = "alisa@gmail.com",
                    Emri = "AlisaMaliqi",
                    PhoneNumber = "045555555",
                    Rruga = "",
                    Shteti = "Kosove",
                    KodiPostal = "10000",
                    Qyteti = "Prishtine"
                }, "Ubt123456!").GetAwaiter().GetResult();

                Perdorusi perdorusi = _konteksti.Perdorusit.
                    FirstOrDefault(x => x.Email == "alisa@gmail.com");

                var identityResult = _userManager.AddToRoleAsync(perdorusi, Sd.RoliAdmin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
