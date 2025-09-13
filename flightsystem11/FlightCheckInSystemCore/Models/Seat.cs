namespace FlightCheckInSystemCore.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int FlightId { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public bool IsBooked { get; set; } = false;
        public string Class { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Flight? Flight { get; set; }
    }
}
