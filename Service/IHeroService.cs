using SpHero.Models;

namespace SpHero.Service
{
    public interface IHeroService
    {
        IEnumerable<Hero> GetAllHeroes();
        Hero GetHeroById(int id);
        void AddHero(Hero hero);
        void UpdateHero(Hero hero);
        void DeleteHero(int id);
    }
}
