using SpHero.Context;
using SpHero.Models;

namespace SpHero.Service
{
    public class HeroService: IHeroService
    {
        private readonly HeroContext _context;

        public HeroService(HeroContext context)
        {
            _context = context;
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            return _context.Heroes.Include(h => h.Powers).Include(h => h.School);
        }

        public Hero GetHeroById(int id)
        {
            return _context.Heroes.Include(h => h.Powers).Include(h => h.School)
                .FirstOrDefault(h => h.Id == id);
        }
        public void AddHero(Hero hero)
        {
            _context.Heroes.Add(hero);
            _context.SaveChanges();
        }

        public void UpdateHero(Hero hero)
        {
            _context.Heroes.Update(hero);
            _context.SaveChanges();
        }

        public void DeleteHero(int id)
        {
            var hero = _context.Heroes.FirstOrDefault(h => h.Id == id);
            if (hero != null)
            {
                _context.Heroes.Remove(hero);
                _context.SaveChanges();
            }
        }
    }

}
