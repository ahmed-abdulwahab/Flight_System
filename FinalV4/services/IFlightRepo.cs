using FinalV4.Models;

namespace FinalV4.services
{
    public interface IFlightRepo
    {
        public List<Flight> GetAll();
        public List<Flight> GetSpecific(string id);
        public void AddFlight(Flight flight);
        public Flight GetFlight(int id);
        public void RemoveFlight(Flight flight);
    }
}
