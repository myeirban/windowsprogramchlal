namespace FlightCheckInSystemCore.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string PassportNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}