using Microsoft.EntityFrameworkCore;

namespace ZeroToHero.CodeFirst.DAL
{
    // [Keyless] // First option
    public class ProductFull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
    }
}
