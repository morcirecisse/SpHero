﻿namespace SpHero.Models
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Hero> Heroes { get; set; }
    }
}
