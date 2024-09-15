using OnlineBookStoreApp.Data;
using OnlineBookStoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreApp.Helpers;

namespace OnlineBookStoreApp.Controllers
{
    [Authorize(Roles = Sd.RoliAdmin)]
    public class EmployeeController : Controller
    {
        private readonly Konteksti _konteksti;

        public EmployeeController(Konteksti konteksti)
        {
            _konteksti = konteksti;
        }

        // List all employees
        public IActionResult Listo()
        {
            var lista = _konteksti.Employees.ToList();
            return View(lista);
        }

        // Create a new employee
        public IActionResult Krijo()
        {
            var entiteti = new Employee(); // Correct Employee model instantiation
            return View(entiteti);
        }

        [HttpPost]
        public IActionResult Krijo(Employee entiteti) // Correct model parameter
        {
            if (ModelState.IsValid)
            {
                _konteksti.Employees.Add(entiteti); // Correct usage of Employees DBSet
                _konteksti.SaveChanges();
                TempData["suksesi"] = "Punonjësi u shtua me sukses";
                return RedirectToAction("Listo");
            }
            return View(entiteti);
        }

        // Edit employee details
        public IActionResult Ndrysho(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var entiteti = _konteksti.Employees.FirstOrDefault(x => x.Id == id);
            if (entiteti == null)
            {
                return NotFound();
            }

            return View(entiteti);
        }

        [HttpPost]
        public IActionResult Ndrysho(Employee entiteti) // Correct model parameter
        {
            if (ModelState.IsValid)
            {
                _konteksti.Employees.Update(entiteti); // Correct usage of Employees DBSet
                _konteksti.SaveChanges();
                TempData["suksesi"] = "Punonjësi u ndryshua me sukses";
                return RedirectToAction("Listo");
            }
            return View(entiteti);
        }

        // Delete employee
        public IActionResult Fshi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var entiteti = _konteksti.Employees.FirstOrDefault(x => x.Id == id);
            if (entiteti == null)
            {
                return NotFound();
            }
            return View(entiteti);
        }

        [HttpPost, ActionName("Fshi")]
        public IActionResult FshiPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var entiteti = _konteksti.Employees.FirstOrDefault(x => x.Id == id);
            if (entiteti == null)
            {
                return NotFound();
            }

            _konteksti.Employees.Remove(entiteti); // Correct usage of Employees DBSet
            _konteksti.SaveChanges();
            TempData["suksesi"] = "Punonjësi u fshi me sukses";
            return RedirectToAction("Listo");
        }
    }
}
