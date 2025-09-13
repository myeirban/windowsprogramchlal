using FlightCheckInSystemCore.Enums;
using System;
using System.Collections.Generic;

namespace FlightCheckInSystemCore.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; } = string.Empty;
        public string DepartureAirport { get; set; } = string.Empty;
        public string ArrivalAirport { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public FlightStatus Status { get; set; } = FlightStatus.Scheduled;

        public List<Seat> Seats { get; set; } = new List<Seat>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}