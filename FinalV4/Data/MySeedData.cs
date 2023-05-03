using FinalV4.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalV4.Data
{
    public class MySeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Cities.Any())
            {
                context.Cities.Add(new City { Id = 1, Name = "Tokyo" });
                context.Cities.Add(new City { Id = 2, Name = "Delhi" });
                context.Cities.Add(new City { Id = 3, Name = "Shanghai" });
                context.Cities.Add(new City { Id = 4, Name = "London" });
                context.Cities.Add(new City { Id = 5, Name = "Paris" });
                context.Cities.Add(new City { Id = 6, Name = "Beijing" });
                context.Cities.Add(new City { Id = 7, Name = "Moscow" });
                context.Cities.Add(new City { Id = 8, Name = "São Paulo" });
                context.Cities.Add(new City { Id = 9, Name = "Mumbai" });
                context.Cities.Add(new City { Id = 10, Name = "Cairo" });
                context.Cities.Add(new City { Id = 11, Name = "Rio de Janeiro" });
                context.Cities.Add(new City { Id = 12, Name = "Aswan" });
                context.Cities.Add(new City { Id = 13, Name = "Berlin" });
                context.Cities.Add(new City { Id = 14, Name = "Amsterdam" });
                context.Cities.Add(new City { Id = 15, Name = "Barcelona" });
                context.Cities.Add(new City { Id = 16, Name = "Madrid" });
                context.Cities.Add(new City { Id = 17, Name = "Jakarta" });
                context.Cities.Add(new City { Id = 18, Name = "Johannesburg" });
                context.Cities.Add(new City { Id = 19, Name = "Killarney" });
                context.Cities.Add(new City { Id = 20, Name = "Kingston" });
                context.Cities.Add(new City { Id = 21, Name = "Kolkata" });
                context.Cities.Add(new City { Id = 22, Name = "Kraków" });
                context.Cities.Add(new City { Id = 23, Name = "Kuala Lumpur" });
                context.Cities.Add(new City { Id = 24, Name = "Lima" });

                context.Cities.Add(new City { Id = 25, Name = "Lisbon" });
                context.Cities.Add(new City { Id = 26, Name = "Los Angeles" });
                context.Cities.Add(new City { Id = 27, Name = "Manila" });
                context.Cities.Add(new City { Id = 28, Name = "Mexico City" });
                context.Cities.Add(new City { Id = 29, Name = "Milan" });
                context.Cities.Add(new City { Id = 30, Name = "Montreal" });
                context.Cities.Add(new City { Id = 31, Name = "Mosco" });
                context.Cities.Add(new City { Id = 32, Name = "Athens" });
                context.SaveChanges();
            }
            if (!context.Hotels.Any())
            {
                context.Hotels.Add(new Hotel { Id = 1, Name = "Nayara", Location = "Mosco", PriceOfRoom = 1500, NumberOfRooms = 30, City_id = 20 });
                context.Hotels.Add(new Hotel { Id = 2, Name = "Beijing", Location = "London", PriceOfRoom = 1800, NumberOfRooms = 30, City_id = 4 });
                context.Hotels.Add(new Hotel { Id = 3, Name = "Capella", Location = "Athens", PriceOfRoom = 1300, NumberOfRooms = 30, City_id = 21 });
                context.Hotels.Add(new Hotel { Id = 4, Name = "Grace", Location = "London", PriceOfRoom = 1000, NumberOfRooms = 30, City_id = 4 });
                context.Hotels.Add(new Hotel { Id = 5, Name = "Kamalame", Location = "Paris", PriceOfRoom = 1250, NumberOfRooms = 30, City_id = 5 });
                context.Hotels.Add(new Hotel { Id = 6, Name = "The Oberoi", Location = "Paris", PriceOfRoom = 2500, NumberOfRooms = 30, City_id = 5 });
                context.Hotels.Add(new Hotel { Id = 7, Name = "Tented", Location = "Paris", PriceOfRoom = 1600, NumberOfRooms = 30, City_id = 5 });


                context.SaveChanges();
            }

            if (!context.Flights.Any())
            {
                context.Flights.Add(new Flight { Id = 1, DateFrom = new DateTime(2023, 4, 4, 10, 30, 0), DateTo = new DateTime(2023, 4, 4, 2, 10, 0), Price = 1500, NumberOfSeats = 20, Comp_id = "343a3749-dab2-4e57-876c-74365898947c", DepartureCityId = 10, ArrivalCityId = 4 });
                context.Flights.Add(new Flight { Id = 2, DateFrom = new DateTime(2023, 4, 2, 11, 50, 0), DateTo = new DateTime(2023, 4, 2, 1, 50, 0), Price = 2500, NumberOfSeats = 30, Comp_id = "d12300a8-3d4e-47bf-a97d-7f5bfa82af14", DepartureCityId = 4, ArrivalCityId = 5 });
                context.Flights.Add(new Flight { Id = 3, DateFrom = new DateTime(2023, 4, 20, 4, 20, 0), DateTo = new DateTime(2023, 4, 20, 9, 40, 0), Price = 1700, NumberOfSeats = 20, Comp_id = "343a3749-dab2-4e57-876c-74365898947c", DepartureCityId = 5, ArrivalCityId = 6 });
                context.Flights.Add(new Flight { Id = 4, DateFrom = new DateTime(2023, 4, 3, 5, 35, 0), DateTo = new DateTime(2023, 4, 3, 7, 0, 0), Price = 1200, NumberOfSeats = 20, Comp_id = "af018efa-5565-4393-becd-862404be7c5b", DepartureCityId = 10, ArrivalCityId = 4 });
                context.Flights.Add(new Flight { Id = 5, DateFrom = new DateTime(2023, 4, 10, 7, 40, 0), DateTo = new DateTime(2023, 4, 10, 9, 10, 0), Price = 1340, NumberOfSeats = 10, Comp_id = "38ac6f62-ec1e-4465-8a39-c487a2b14c7c", DepartureCityId = 4, ArrivalCityId = 5 });
                context.Flights.Add(new Flight { Id = 6, DateFrom = new DateTime(2023, 4, 6, 10, 30, 0), DateTo = new DateTime(2023, 4, 6, 1, 30, 0), Price = 1000, NumberOfSeats = 30, Comp_id = "af018efa-5565-4393-becd-862404be7c5b", DepartureCityId = 3, ArrivalCityId = 2 });

                context.Flights.Add(new Flight { Id = 7,  DateFrom = new DateTime(2023, 4, 15, 10, 20, 0), DateTo = new DateTime(2023, 4, 15, 2, 30, 0), Price = 1550, NumberOfSeats = 40, Comp_id = "38ac6f62-ec1e-4465-8a39-c487a2b14c7c", DepartureCityId = 5, ArrivalCityId = 4 });
                context.Flights.Add(new Flight { Id = 8,  DateFrom = new DateTime(2023, 4, 25, 5, 45, 0), DateTo = new DateTime(2023, 4, 25, 9, 30, 0), Price = 1230, NumberOfSeats = 30, Comp_id = "343a3749-dab2-4e57-876c-74365898947c", DepartureCityId = 6, ArrivalCityId = 5 });
                context.Flights.Add(new Flight { Id = 9,  DateFrom = new DateTime(2023, 4, 10, 4, 50, 0), DateTo = new DateTime(2023, 4, 10, 6, 10, 0), Price = 1780, NumberOfSeats = 10, Comp_id = "d12300a8-3d4e-47bf-a97d-7f5bfa82af14", DepartureCityId = 4, ArrivalCityId = 10 });
                context.Flights.Add(new Flight { Id = 10, DateFrom = new DateTime(2023, 4, 24, 5, 10, 0), DateTo = new DateTime(2023, 4, 24, 10, 10, 0), Price = 1450, NumberOfSeats = 20, Comp_id = "d12300a8-3d4e-47bf-a97d-7f5bfa82af14", DepartureCityId = 4, ArrivalCityId = 10 });
                context.Flights.Add(new Flight { Id = 11, DateFrom = new DateTime(2023, 4, 13, 9, 55, 0), DateTo = new DateTime(2023, 4, 13, 11, 55, 0), Price = 1220, NumberOfSeats = 30, Comp_id = "af018efa-5565-4393-becd-862404be7c5b", DepartureCityId = 5, ArrivalCityId = 4 });
                context.Flights.Add(new Flight { Id = 12, DateFrom = new DateTime(2023, 4, 9, 8, 15, 0), DateTo = new DateTime(2023, 4, 9, 12, 15, 0), Price = 1800, NumberOfSeats = 20, Comp_id = "d12300a8-3d4e-47bf-a97d-7f5bfa82af14", DepartureCityId = 2, ArrivalCityId = 3 });


                new DateTime(2022, 04, 01, 10, 30, 0);
                context.SaveChanges();
            }


        }
    }
}
