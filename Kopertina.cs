using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStoreApp.Models
{
    [Table("Kopertina")]
    public class Kopertina
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Specifikoni emrin")]
        public string Emri { get; set; }
    }
}
