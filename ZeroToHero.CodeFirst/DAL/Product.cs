using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeroToHero.CodeFirst.DAL
{
    [Table("ProductTb", Schema = "products")]
    public class Product
    {
        //[Column(Order = 1)]
        //[Key]
        public int Product_Id { get; set; }
        //[Column("name2", Order =  2)]
        // if nullable is open, nullable:false
        //[Required] // side for validation is important
        //[MaxLength(100)] // character length
        // Fluent Validation
        //[StringLength(100, MinimumLength = 100)] // Side to validation
        public string? Name { get; set; }
        //[Column("price2", Order = 3, TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Barcode { get; set; }
    }
}
