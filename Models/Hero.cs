namespace SpHero.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Power> Powers { get; set; }
        public School School { get; set; }
    }
}
