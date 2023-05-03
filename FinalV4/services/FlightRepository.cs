using FinalV4.Data;
using FinalV4.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalV4.services
{
    //Implement All CRUD Operations or any Actions that will be used Multiple Times!!!
    public class FlightRepository:IFlightRepo
    {
        ApplicationDbContext db;
        public FlightRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Flight> GetAll()
        {
            var Flights = db.Flights.Include(a => a.Company)
                                    .Include(a => a.DepartureCity)
                                    .Include(a => a.ArrivalCity).ToList();

            return Flights;
        }
        public List<Flight> GetSpecific(string id)
        {
            var Flights = db.Flights.Include(a => a.Company)
                                    .Include(a => a.DepartureCity)
                                    .Include(a => a.ArrivalCity).Where(a=>a.Comp_id==id).ToList();

            return Flights;
        }

        public void AddFlight(Flight flight)
        {
            db.Flights.Add(flight);
            db.SaveChanges();
        }
        public Flight GetFlight(int id)
        {
            return db.Flights.Find(id) ?? new Flight();
        }
        public void RemoveFlight(Flight flight)
        {
            db.Flights.Remove(flight);
            db.SaveChanges();
        }
    }
}
