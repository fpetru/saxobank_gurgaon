using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Core_webApp.Models
{
    public partial class Product
    {
        [Key] //Identity and Primary Key
        public int ProductRowId { get; set; }
        [Required(ErrorMessage ="ProdutId is Required")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "ProductName is Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "BasePrice is Required")]
        public int BasePrice { get; set; }
        [Required(ErrorMessage = "CategoryName is Required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Manufacturer is Required")]
        public string Manufacturer { get; set; }
    }
}
