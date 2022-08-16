using Microsoft.EntityFrameworkCore;

namespace ZeroToHero.CodeFirst.DAL
{
    //[Owned]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
