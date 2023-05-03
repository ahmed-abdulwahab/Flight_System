using FinalV4.Data;
using FinalV4.Models;

namespace FinalV4.services
{
    //Implement All CRUD Operations or any Actions that will be used Multiple Times!!!
    public class UserRepositotry:IUserRepo
    {

        ApplicationDbContext db;
        public UserRepositotry(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ApplicationUser Get(string id)
        {
            return db.Users.Find(id) ?? new ApplicationUser();
        }



        public List<ApplicationUser> GetAll()
        {
            var Companies = db.Users.Where(a => a.Fname == null).ToList();

            return Companies;
        }

        public void AddFlight(string id, Flight flight)
        {
            var user = db.Users.Find(id);
            user.Flights.Add(flight);
            db.SaveChanges();
        }
        public void RemoveUser(ApplicationUser user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

    }
}
