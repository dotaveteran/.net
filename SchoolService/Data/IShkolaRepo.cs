using SchoolService.Models;

namespace SchoolService.Data
{
    public interface IShkolaRepo    
    {
        bool SaveChanges();
        
        IEnumerable<Shkola> GetAllPlatforms();
        Shkola GetShkolaById(int id);
        void CreateShkola(Shkola plat);
    }
}