using FlightCheckInSystemCore.Models;
using FlightCheckInSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Globalization;
using System.Threading.Tasks;
using System.Data.Common;
using System.Linq;

namespace FlightCheckInSystem.Data.Repositories
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public BookingRepository(string connectionString) : base(connectionString) { }

        public async Task<Booking?> GetBookingByIdAsync(int bookingId)
        {
            using var connection = GetConnection();
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                SELECT b.*, p.PassportNumber, p.FirstName, p.LastName, 
                       f.FlightNumber, f.DepartureAirport, f.ArrivalAirport, f.DepartureTime AS FlightDepartureTime, f.ArrivalTime AS FlightArrivalTime, f.Status AS FlightStatus,
                       s.SeatNumber AS AssignedSeatNumber
                FROM Bookings b
                JOIN Passengers p ON b.PassengerId = p.PassengerId
                JOIN Flights f ON b.FlightId = f.FlightId
                LEFT JOIN Seats s ON b.SeatId = s.SeatId
                WHERE b.BookingId = @BookingId", connection);
            command.Parameters.AddWithValue("@BookingId", bookingId);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
                return MapToBookingWithDetails(reader);

            return null;
        }

        public async Task<Booking?> GetBookingByPassengerAndFlightAsync(int passengerId, int flightId)
        {
            using var connection = GetConnection();
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                SELECT b.*, p.PassportNumber, p.FirstName, p.LastName, 
                       f.FlightNumber, f.DepartureAirport, f.ArrivalAirport, f.DepartureTime AS FlightDepartureTime, f.ArrivalTime AS FlightArrivalTime, f.Status AS FlightStatus,
                       s.SeatNumber AS AssignedSeatNumber
                FROM Bookings b
                JOIN Passengers p ON b.PassengerId = p.PassengerId
                JOIN Flights f ON b.FlightId = f.FlightId
                LEFT JOIN Seats s ON b.SeatId = s.SeatId
                WHERE b.PassengerId = @PassengerId AND b.FlightId = @FlightId", connection);
            command.Parameters.AddWithValue("@PassengerId", passengerId);
            command.Parameters.AddWithValue("@FlightId", flightId);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
                return MapToBookingWithDetails(reader);

            return null;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByFlightIdAsync(int flightId)
        {
            var bookings = new List<Booking>();
            using var connection = GetConnection();
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                SELECT b.*, p.PassportNumber, p.FirstName, p.LastName, 
                       f.FlightNumber, f.DepartureAirport, f.ArrivalAirport, f.DepartureTime AS FlightDepartureTime, f.ArrivalTime AS FlightArrivalTime, f.Status AS FlightStatus,
                       s.SeatNumber AS AssignedSeatNumber
                FROM Bookings b
                JOIN Passengers p ON b.PassengerId = p.PassengerId
                JOIN Flights f ON b.FlightId = f.FlightId
                LEFT JOIN Seats s ON b.SeatId = s.SeatId
                WHERE b.FlightId = @FlightId", connection);
            command.Parameters.AddWithValue("@FlightId", flightId);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                bookings.Add(MapToBookingWithDetails(reader));

            return bookings;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByPassengerIdAsync(int passengerId)
        {
            var bookings = new List<Booking>();
            using var connection = GetConnection();
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                SELECT b.*, p.PassportNumber, p.FirstName, p.LastName, 
                       f.FlightNumber, f.DepartureAirport, f.ArrivalAirport, f.DepartureTime AS FlightDepartureTime, f.ArrivalTime AS FlightArrivalTime, f.Status AS FlightStatus,
                       s.SeatNumber AS AssignedSeatNumber
                FROM Bookings b
                JOIN Passengers p ON b.PassengerId = p.PassengerId
                JOIN Flights f ON b.FlightId = f.FlightId
                LEFT JOIN Seats s ON b.SeatId = s.SeatId
                WHERE b.PassengerId = @PassengerId", connection);
            command.Parameters.AddWithValue("@PassengerId", passengerId);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                bookings.Add(MapToBookingWithDetails(reader));

            return bookings;
        }

        public async Task<int> AddBookingAsync(Booking booking)
        {
            using var connection = GetConnection();
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                INSERT INTO Bookings (PassengerId, FlightId, SeatId, ReservationDate, IsCheckedIn, CheckInTime) 
                VALUES (@PassengerId, @FlightId, @SeatId, @ReservationDate, @IsCheckedIn, @CheckInTime);
                SELECT last_insert_rowid();", connection);
            command.Parameters.AddWithValue("@PassengerId", booking.PassengerId);
            command.Parameters.AddWithValue("@FlightId", booking.FlightId);
            command.Parameters.AddWithValue("@SeatId", booking.SeatId.HasValue ? (object)booking.SeatId : DBNull.Value);
            command.Parameters.AddWithValue("@ReservationDate", booking.ReservationDate.ToString("o"));
            command.Parameters.AddWithValue("@IsCheckedIn", booking.IsCheckedIn ? 1 : 0);
            command.Parameters.AddWithValue("@CheckInTime", booking.CheckInTime.HasValue ? (object)booking.CheckInTime.Value.ToString("o") : DBNull.Value);

            var newId = await command.ExecuteScalarAsync();
            return Convert.ToInt32(newId);
        }

        public async Task<bool> UpdateBookingAsync(Booking booking)
        {
            using var connection = GetConnection();
            await connection.OpenAsync();
            var command = new SqliteCommand(@"
                UPDATE Bookings SET 
                PassengerId = @PassengerId, FlightId = @FlightId, SeatId = @SeatId, 
                ReservationDate = @ReservationDate, IsCheckedIn = @IsCheckedIn, CheckInTime = @CheckInTime
                WHERE BookingId = @BookingId", connection);
            command.Parameters.AddWithValue("@PassengerId", booking.PassengerId);
            command.Parameters.AddWithValue("@FlightId", booking.FlightId);
            command.Parameters.AddWithValue("@SeatId", booking.SeatId.HasValue ? booking.SeatId : DBNull.Value);
            command.Parameters.AddWithValue("@ReservationDate", booking.ReservationDate.ToString("o"));
            command.Parameters.AddWithValue("@IsCheckedIn", booking.IsCheckedIn ? 1 : 0);
            command.Parameters.AddWithValue("@CheckInTime", booking.CheckInTime.HasValue ? booking.CheckInTime.Value.ToString("o") : DBNull.Value);
            command.Parameters.AddWithValue("@BookingId", booking.BookingId);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            using var connection = GetConnection();
            await connection.OpenAsync();
            var command = new SqliteCommand("DELETE FROM Bookings WHERE BookingId = @BookingId", connection);
            command.Parameters.AddWithValue("@BookingId", bookingId);
            return await command.ExecuteNonQueryAsync() > 0;
        }

        // Mapping methods
        private Booking MapToBooking(DbDataReader reader)
        {
            return new Booking
            {
                BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                PassengerId = reader.GetInt32(reader.GetOrdinal("PassengerId")),
                FlightId = reader.GetInt32(reader.GetOrdinal("FlightId")),
                SeatId = reader.IsDBNull(reader.GetOrdinal("SeatId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("SeatId")),
                ReservationDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("ReservationDate")), null, DateTimeStyles.RoundtripKind),
                IsCheckedIn = reader.GetInt32(reader.GetOrdinal("IsCheckedIn")) == 1,
                CheckInTime = reader.IsDBNull(reader.GetOrdinal("CheckInTime")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("CheckInTime")), null, DateTimeStyles.RoundtripKind)
            };
        }

        private Booking MapToBookingWithDetails(DbDataReader reader)
        {
            var booking = MapToBooking(reader);

            booking.Passenger = new Passenger
            {
                PassengerId = booking.PassengerId,
                PassportNumber = reader.GetString(reader.GetOrdinal("PassportNumber")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName"))
            };

            booking.Flight = new Flight
            {
                FlightId = booking.FlightId,
                FlightNumber = reader.GetString(reader.GetOrdinal("FlightNumber")),
                DepartureAirport = reader.GetString(reader.GetOrdinal("DepartureAirport")),
                ArrivalAirport = reader.GetString(reader.GetOrdinal("ArrivalAirport")),
                DepartureTime = DateTime.Parse(reader.GetString(reader.GetOrdinal("FlightDepartureTime")), null, DateTimeStyles.RoundtripKind),
                ArrivalTime = DateTime.Parse(reader.GetString(reader.GetOrdinal("FlightArrivalTime")), null, DateTimeStyles.RoundtripKind),
                Status = Enum.Parse<FlightCheckInSystemCore.Enums.FlightStatus>(reader.GetString(reader.GetOrdinal("FlightStatus")))
            };

            if (booking.SeatId.HasValue && !reader.IsDBNull(reader.GetOrdinal("AssignedSeatNumber")))
            {
                booking.Seat = new Seat
                {
                    SeatId = booking.SeatId.Value,
                    FlightId = booking.FlightId,
                    SeatNumber = reader.GetString(reader.GetOrdinal("AssignedSeatNumber")),
                    IsBooked = true
                };
            }

            return booking;
        }
    }
}
