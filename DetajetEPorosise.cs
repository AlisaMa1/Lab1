using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace OnlineBookStoreApp.Models
{
	public class DetajetEPorosise
	{
		public int Id { get; set; }
		[Required]
		public int PorosiaId { get; set; }
		[ForeignKey("PorosiaId")]
		[ValidateNever]
		public Porosia Porosia { get; set; }

		[Required]
		public int ProduktiId { get; set; }
		[ForeignKey("ProduktiId")]
		[ValidateNever]
		public Produkti Produkti { get; set; }
		public double Sasia { get; set; }
		public double Cmimi { get; set; }
	}
}
