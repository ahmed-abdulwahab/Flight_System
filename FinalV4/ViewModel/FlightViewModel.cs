namespace FinalV4.ViewModel
{
    public class FlightViewModel
    {
        public DateTime DateFrom { get; set; }
        public decimal price { get; set; }
        public int NumberOfSeates { get; set; }
        public int DepatureCityId { get; set; }
        public int ArrivalCityId { get; set; }

        public string? ArrivalCityName { get; set; }
        public string? CompanyId { get; set; }
    }
}
