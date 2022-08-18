using Microsoft.EntityFrameworkCore;

namespace ZeroToHero.CodeFirst.DAL
{
    // [Keyless] // First option
    public class ProductFull
    {
        public int Product_Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Height { get; set; }
    }
}
