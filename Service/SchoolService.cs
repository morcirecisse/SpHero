using SpHero.Context;
using SpHero.Models;

namespace SpHero.Service
{
    public class SchoolService : ISchoolService
    {
        private readonly SpHeroContext _context;

        public SchoolService(SpHeroContext context)
        {
            _context = context;
        }

        public IEnumerable<School> GetAllSchools()
        {
            return _context.Schools.Include(s => s.Heroes);
        }

        public School GetSchoolById(int id)
        {
            return _context.Schools.Include(s => s.Heroes)
                .FirstOrDefault(s => s.Id == id);
        }

        public void AddSchool(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
        }

        public void UpdateSchool(School school)
        {
            _context.Schools.Update(school);
            _context.SaveChanges();
        }

        public void DeleteSchool(int id)
        {
            var school = _context.Schools.FirstOrDefault(s => s.Id == id);
            if (school != null)
            {
                _context.Schools.Remove(school);
                _context.SaveChanges();
            }
        }
    }
}
