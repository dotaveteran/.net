using SchoolService.Models;

namespace SchoolService.Data
{
    public class ShkolaRepo : IShkolaRepo
    {
        private readonly AppDbContext _context;

        public ShkolaRepo(AppDbContext context)
        {
            _context = context;
        }
        
        public void CreateShkola(Shkola plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Shkolas.Add(plat);
        }

        public IEnumerable<Shkola> GetAllPlatforms()
        {
            return _context.Shkolas.ToList();
        }

        public Shkola GetShkolaById(int id)
        {
            return _context.Shkolas.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}