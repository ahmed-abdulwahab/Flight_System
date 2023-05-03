using FinalV4.Models;

namespace FinalV4.services
{
    public interface ICityRepo
    {
        public List<City> GetAll();
        public List<string> GetAllNames();
    }

}
