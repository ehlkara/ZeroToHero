using System;
namespace ZeroToHero.CodeFirst.DTOs
{
	public class ProductDto
	{
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int? Width { get; set; }
    }
}

