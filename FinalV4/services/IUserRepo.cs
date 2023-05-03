using FinalV4.Models;

namespace FinalV4.services
{
    public interface IUserRepo
    {
        public List<ApplicationUser> GetAll();
        public void RemoveUser(ApplicationUser user);
        public ApplicationUser Get(string id);
        public void AddFlight(string id, Flight flight);
    }
}
