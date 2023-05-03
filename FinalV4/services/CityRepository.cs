using FinalV4.Data;
using FinalV4.Models;

namespace FinalV4.services
{
    //Implement All CRUD Operations or any Actions that will be used Multiple Times!!!
    public class CityRepository:ICityRepo
    {
        ApplicationDbContext db;
        public CityRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<City> GetAll()
        {
            var Cities = db.Cities.ToList();

            return Cities;
        }

        public List<string> GetAllNames()
        {
            var NamesOfCities = db.Cities.Select(c => c.Name).ToList();
            return NamesOfCities;
        }
    }
}
