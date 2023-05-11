using SpHero.Models;

namespace SpHero.Service
{
    public interface ISchoolService
    {
        IEnumerable<School> GetAllSchools();
        School GetSchoolById(int id);
        void AddSchool(School school);
        void UpdateSchool(School school);
        void DeleteSchool(int id);
    }
}
