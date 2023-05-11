using SpHero.Context;
using SpHero.Models;

namespace SpHero.Service
{
    public class PowerService: IPowerService
    {
        private readonly HeroContext _context;

        public PowerService(HeroContext context)
        {
            _context = context;
        }

        public IEnumerable<Power> GetAllPowers()
        {
            return _context.Powers.Include(p => p.Heroes);
        }

        public Power GetPowerById(int id)
        {
            return _context.Powers.Include(p => p.Heroes)
                .FirstOrDefault(p => p.Id == id);
        }

        public void AddPower(Power power)
        {
            _context.Powers.Add(power);
            _context.SaveChanges();
        }

        public void UpdatePower(Power power)
        {
            _context.Powers.Update(power);
            _context.SaveChanges();
        }

        public void DeletePower(int id)
        {
            var power = _context.Powers.FirstOrDefault(p => p.Id == id);
            if (power != null)
            {
                _context.Powers.Remove(power);
                _context.SaveChanges();
            }
        }
    }
}
