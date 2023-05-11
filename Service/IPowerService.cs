using SpHero.Models;

namespace SpHero.Service
{
    public interface IPowerService
    {
        IEnumerable<Power> GetAllPowers();
        Power GetPowerById(int id);
        void AddPower(Power power);
        void UpdatePower(Power power);
        void DeletePower(int id);
    }
}
