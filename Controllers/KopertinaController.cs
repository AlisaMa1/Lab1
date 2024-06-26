using OnlineBookStoreApp.Data;
using OnlineBookStoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreApp.Helpers;


namespace OnlineBookStoreApp.Controllers
{
    [Authorize(Roles = Sd.RoliAdmin)]
    public class KopertinaController : Controller
    {
        private readonly Konteksti _konteksti;

        public KopertinaController(Konteksti konteksti 
            )
        {
            _konteksti = konteksti;
        }
        public IActionResult Listo()
        {
            var lista = _konteksti.Kopertinat.ToList();
            return View(lista);
        }

        public IActionResult Krijo()
        {
            var entiteti = new Kopertina();
            return View(entiteti);
        }
        [HttpPost]
        public IActionResult Krijo(Kopertina entiteti)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Kopertinat.Add(entiteti);
                _konteksti.SaveChanges();
                TempData["suksesi"] = "U shtua me sukses";
                return RedirectToAction("Listo");
            }
            return View();
        }
        public IActionResult Ndrysho(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            var entiteti = _konteksti.Kopertinat.FirstOrDefault(x => x.Id == id);
            if (entiteti==null)
            {
                return NotFound();
            }
            
            return View(entiteti);
        }
        [HttpPost]
        public IActionResult Ndrysho(Kopertina entiteti)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Kopertinat.Update(entiteti);
                _konteksti.SaveChanges();
                TempData["suksesi"] = "U ndryshua me sukses";
                return RedirectToAction("Listo");
            }
            return View();
        }
        public IActionResult Fshi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var entiteti = _konteksti.Kopertinat.FirstOrDefault(x => x.Id == id);
            if (entiteti == null)
            {
                return NotFound();
            }
            return View(entiteti);
        }
        [HttpPost,ActionName("Fshi")]
        public IActionResult FshiPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var entiteti = _konteksti.Kopertinat.FirstOrDefault(x => x.Id == id);
            if (entiteti == null)
            {
                return NotFound();
            }

            _konteksti.Remove(entiteti);
            _konteksti.SaveChanges();
            TempData["suksesi"] = "U fshi me sukses";
            return RedirectToAction("Listo");
        }
    }
}
