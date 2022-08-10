using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroToHero.CodeFirst.DAL
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public int ProductRef_Id { get; set; }
        [ForeignKey("ProductRef_Id")]
        public Product Product { get; set; }
    }
}
