namespace ZeroToHero.CodeFirst.DAL
{
    // Table Per Hierarchy
    public class Manager //: BasePerson
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int Grade { get; set; }
    }
}
