using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeroToHero.CodeFirst.DAL
{
    //[Table("ProductTb", Schema = "products")]
    public class Product
    {
        //[Column(Order = 1)]
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        //[Column(TypeName = "nvarchar(200)")]
        public string Url { get; set; }

        //[Column("name2", Order =  2)]
        // if nullable is open, nullable:false
        //[Required] // side for validation is important
        //[MaxLength(100)] // character length
        // Fluent Validation
        //[StringLength(100, MinimumLength = 100)] // Side to validation
        //[Unicode(false)] // varchar()
        public string Name { get; set; }
        //[Column("price2", Order = 3, TypeName = "decimal(18,2)")]
        [Precision(18,2)]
        public decimal Price { get; set; }
        //public int Kdv { get; set; }

        public int Stock { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public DateTime CreatedDate { get; set; } = DateTime.Now;

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime LastAccessDate { get; set; }
        //[NotMapped] // Entiy Properties first option
        public int Barcode { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal PriceKdv { get; set; }
        //public int? Category_Id { get; set; }

        //[ForeignKey("Category_Id")] // attribute way
        // Navigation property
        //public Category Category { get; set; }

        //Shadow property

        //Another way
        public int CategoryId { get; set; }
        // Domain Driven Design best practice
        public virtual Category Category { get; set; }
        public virtual ProductFeature ProductFeature { get; set; }
    }
}
