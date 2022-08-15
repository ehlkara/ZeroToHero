using Microsoft.EntityFrameworkCore;

namespace ZeroToHero.CodeFirst.DAL
{
    // Table Per Hierarchy
    public class Employee : BasePerson
    {
        [Precision(18,2)]
        public decimal Salary { get; set; }
    }
}
