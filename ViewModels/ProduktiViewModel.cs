using OnlineBookStoreApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineBookStoreApp.ViewModels
{
	public class ProduktiViewModel
	{
        public Produkti Produkti { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Kategorite { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Kopertina { get; set; }
	}
}
