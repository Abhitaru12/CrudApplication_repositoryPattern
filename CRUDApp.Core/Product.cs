
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CRUDApp.Core
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]

        public int Qty { get; set; }

    }
}
