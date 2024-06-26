using OnlineBookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OnlineBookStoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using OnlineBookStoreApp.Helpers;


namespace OnlineBookStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Konteksti _konteksti;

        public HomeController(ILogger<HomeController> logger, Konteksti konteksti)
        {
            _logger = logger;
            _konteksti = konteksti;
        }

        public IActionResult Index()
        {
            var list = _konteksti.Produktet.Include(x => x.Kategoria)
                .Include(x => x.Kopertina).ToList();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Detajet(int produktiId)
        {
            Shporta shporta = new()
            {
                Sasia = 1,
                ProduktiId = produktiId,
                Produkti = _konteksti.Produktet.
                    Include(x => x.Kategoria).
                    Include(x => x.Kopertina).
                    FirstOrDefault(u => u.Id == produktiId)
            };
            return View(shporta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Detajet(Shporta shporta)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shporta.PerdorusiId = claim.Value;

            Shporta shportaNgaDb = _konteksti.Shportat.FirstOrDefault(
                u => u.PerdorusiId == claim.Value
                     && u.ProduktiId == shporta.ProduktiId);


            if (shportaNgaDb == null)
            {
                _konteksti.Shportat.Add(shporta);
                _konteksti.SaveChanges();
                HttpContext.Session.SetInt32(Sd.ShportNeSession,
                    _konteksti.Shportat.Where(u => u.PerdorusiId == claim.Value).ToList().Count);
            }
            else
            {
                shportaNgaDb.Sasia += 1;
                _konteksti.Shportat.Update(shportaNgaDb);
                _konteksti.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}