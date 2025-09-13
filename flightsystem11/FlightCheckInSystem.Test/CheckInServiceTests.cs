using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightCheckInSystem.Business.Services;
using FlightCheckInSystemCore.Models;
using FlightCheckInSystem.Data.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightCheckInSystemCore.Enums;
using System.Linq;

namespace FlightCheckInSystem.Tests
{
    [TestClass]
    public class CheckInServiceTests
    {
        private TestBookingRepository _bookingRepo;
        private TestSeatRepository _seatRepo;
        private TestFlightRepository _flightRepo;
        private TestPassengerRepository _passengerRepo;
        private CheckInService _checkInService;

        [TestInitialize]
        public void Setup()
        {
            _bookingRepo = new TestBookingRepository();
            _seatRepo = new TestSeatRepository();
            _flightRepo = new TestFlightRepository();
            _passengerRepo = new TestPassengerRepository();

            _checkInService = new CheckInService(
                _bookingRepo,
                _seatRepo,
                _flightRepo,
                _passengerRepo
            );
        }

        [TestMethod]
        public async Task FindBookingForCheckIn_WithValidData_ReturnsBooking()
        {
            // Arrange
            string passportNumber = "AB123456";
            string flightNumber = "FL123";

            var passenger = new Passenger
            {
                PassengerId = 1,
                PassportNumber = passportNumber,
                FirstName = "John",
                LastName = "Doe"
            };
            await _passengerRepo.CreatePassengerAsync(passenger);

            var flight = new Flight
            {
                FlightId = 1,
                FlightNumber = flightNumber,
                Status = FlightStatus.CheckingIn,
                DepartureAirport = "ULN",
                ArrivalAirport = "ICN",
                DepartureTime = DateTime.UtcNow.AddHours(2),
                ArrivalTime = DateTime.UtcNow.AddHours(5)
            };
            await _flightRepo.AddFlightAsync(flight);

            var booking = new Booking
            {
                BookingId = 1,
                PassengerId = passenger.PassengerId,
                FlightId = flight.FlightId,
                IsCheckedIn = false,
                ReservationDate = DateTime.UtcNow
            };
            await _bookingRepo.CreateBookingAsync(booking);

            // Act
            var (resultBooking, message) = await _checkInService.FindBookingForCheckInAsync(passportNumber, flightNumber);

            // Assert
            Assert.IsNotNull(resultBooking);
            Assert.AreEqual(booking.BookingId, resultBooking.BookingId);
            Assert.IsTrue(message.Contains("Booking found and ready for check-in"));
        }

        [TestMethod]
        public async Task AssignSeatToBooking_WhenSuccessful_GeneratesBoardingPass()
        {
            // Arrange
            int bookingId = 1;
            int seatId = 1;
            int flightId = 1;
            int passengerId = 1;

            var passenger = new Passenger
            {
                PassengerId = passengerId,
                FirstName = "John",
                LastName = "Doe",
                PassportNumber = "AB123456"
            };
            await _passengerRepo.CreatePassengerAsync(passenger);

            var flight = new Flight
            {
                FlightId = flightId,
                FlightNumber = "FL123",
                DepartureAirport = "ULN",
                ArrivalAirport = "ICN",
                DepartureTime = DateTime.UtcNow.AddHours(2),
                ArrivalTime = DateTime.UtcNow.AddHours(5),
                Status = FlightStatus.CheckingIn
            };
            await _flightRepo.AddFlightAsync(flight);

            var seat = new Seat
            {
                SeatId = seatId,
                FlightId = flightId,
                IsBooked = false,
                SeatNumber = "12A",
                Class = "Economy",
                Price = 200.00m
            };
            await _seatRepo.AddSeatAsync(seat);

            var booking = new Booking
            {
                BookingId = bookingId,
                FlightId = flightId,
                PassengerId = passengerId,
                IsCheckedIn = false,
                ReservationDate = DateTime.UtcNow,
                Passenger = passenger,
                Flight = flight
            };
            await _bookingRepo.CreateBookingAsync(booking);

            // Act
            var (success, message, boardingPass) = await _checkInService.AssignSeatToBookingAsync(bookingId, seatId);

            // Assert
            Assert.IsTrue(success);
            Assert.IsNotNull(boardingPass);
            Assert.AreEqual("12A", boardingPass.SeatNumber);
            Assert.AreEqual("John Doe", boardingPass.PassengerName);
            Assert.AreEqual("FL123", boardingPass.FlightNumber);
            Assert.AreEqual("ULN", boardingPass.DepartureAirport);
            Assert.AreEqual("ICN", boardingPass.ArrivalAirport);
        }

        [TestMethod]
        public async Task AssignSeatToBooking_WhenSeatIsAlreadyTaken_HandlesRaceConditionGracefully()
        {
            // Arrange
            int bookingId = 1;
            int seatId = 1;
            int flightId = 1;
            int passengerId = 1;

            var passenger = new Passenger
            {
                PassengerId = passengerId,
                FirstName = "John",
                LastName = "Doe",
                PassportNumber = "AB123456"
            };
            await _passengerRepo.CreatePassengerAsync(passenger);

            var flight = new Flight
            {
                FlightId = flightId,
                FlightNumber = "FL123",
                DepartureAirport = "ULN",
                ArrivalAirport = "ICN",
                DepartureTime = DateTime.UtcNow.AddHours(2),
                ArrivalTime = DateTime.UtcNow.AddHours(5),
                Status = FlightStatus.CheckingIn
            };
            await _flightRepo.AddFlightAsync(flight);

            var booking = new Booking
            {
                BookingId = bookingId,
                FlightId = flightId,
                PassengerId = passengerId,
                IsCheckedIn = false,
                ReservationDate = DateTime.UtcNow,
                Passenger = passenger,
                Flight = flight
            };
            await _bookingRepo.CreateBookingAsync(booking);

            var seat = new Seat
            {
                SeatId = seatId,
                FlightId = flightId,
                IsBooked = true,  // Seat is already taken
                SeatNumber = "12A",
                Class = "Economy",
                Price = 200.00m
            };
            await _seatRepo.AddSeatAsync(seat);

            // Act
            var (success, message, boardingPass) = await _checkInService.AssignSeatToBookingAsync(bookingId, seatId);

            // Assert
            Assert.IsFalse(success);
            Assert.IsTrue(message.Contains("Seat is no longer available") || message.Contains("Failed to book the seat"));
            Assert.IsNull(boardingPass);
        }

        [TestMethod]
        public async Task FindBookingForCheckIn_WhenFlightClosed_ReturnsAppropriateMessage()
        {
            // Arrange
            string passportNumber = "AB123456";
            string flightNumber = "FL123";

            var passenger = new Passenger
            {
                PassengerId = 1,
                PassportNumber = passportNumber,
                FirstName = "John",
                LastName = "Doe"
            };
            await _passengerRepo.CreatePassengerAsync(passenger);

            var flight = new Flight
            {
                FlightId = 1,
                FlightNumber = flightNumber,
                Status = FlightStatus.Departed, // Flight has departed
                DepartureAirport = "ULN",
                ArrivalAirport = "ICN",
                DepartureTime = DateTime.UtcNow.AddHours(-2), // Departed 2 hours ago
                ArrivalTime = DateTime.UtcNow.AddHours(1)
            };
            await _flightRepo.AddFlightAsync(flight);

            var booking = new Booking
            {
                BookingId = 1,
                PassengerId = passenger.PassengerId,
                FlightId = flight.FlightId,
                IsCheckedIn = false,
                ReservationDate = DateTime.UtcNow
            };
            await _bookingRepo.CreateBookingAsync(booking);

            // Act
            var (resultBooking, message) = await _checkInService.FindBookingForCheckInAsync(passportNumber, flightNumber);

            // Assert
            Assert.IsNotNull(resultBooking);
            Assert.IsTrue(message.Contains("not currently open for check-in"));
        }

        [TestMethod]
        public async Task GenerateBoardingPass_WhenBookingDataIsIncomplete_ReturnsNull()
        {
            // Arrange
            int bookingId = 1;
            var incompleteBooking = new Booking
            {
                BookingId = bookingId,
                IsCheckedIn = true,
                SeatId = 1,
                FlightId = 1,
                PassengerId = 1
                // Missing Passenger and Flight navigation properties
            };
            await _bookingRepo.CreateBookingAsync(incompleteBooking);

            // Act
            var boardingPass = await _checkInService.GenerateBoardingPassAsync(bookingId);

            // Assert
            Assert.IsNull(boardingPass);
        }

        [TestMethod]
        public async Task FindBookingForCheckIn_WhenPassengerNotFound_ReturnsNull()
        {
            // Arrange
            string passportNumber = "NOTFOUND";
            string flightNumber = "FL123";

            // Act
            var (resultBooking, message) = await _checkInService.FindBookingForCheckInAsync(passportNumber, flightNumber);

            // Assert
            Assert.IsNull(resultBooking);
            Assert.IsTrue(message.Contains("Passenger with this passport number not found"));
        }

        [TestMethod]
        public async Task FindBookingForCheckIn_WhenFlightNotFound_ReturnsNull()
        {
            // Arrange
            string passportNumber = "AB123456";
            string flightNumber = "NOTFOUND";

            var passenger = new Passenger
            {
                PassengerId = 1,
                PassportNumber = passportNumber,
                FirstName = "John",
                LastName = "Doe"
            };
            await _passengerRepo.CreatePassengerAsync(passenger);

            // Act
            var (resultBooking, message) = await _checkInService.FindBookingForCheckInAsync(passportNumber, flightNumber);

            // Assert
            Assert.IsNull(resultBooking);
            Assert.IsTrue(message.Contains("Flight with number NOTFOUND not found"));
        }

        [TestMethod]
        public async Task AssignSeatToBooking_WhenBookingNotFound_ReturnsFailure()
        {
            // Arrange
            int bookingId = 999; // Non-existent booking
            int seatId = 1;

            // Act
            var (success, message, boardingPass) = await _checkInService.AssignSeatToBookingAsync(bookingId, seatId);

            // Assert
            Assert.IsFalse(success);
            Assert.IsTrue(message.Contains("Booking not found"));
            Assert.IsNull(boardingPass);
        }

        [TestMethod]
        public async Task AssignSeatToBooking_WhenSeatNotFound_ReturnsFailure()
        {
            // Arrange
            int bookingId = 1;
            int seatId = 999; // Non-existent seat

            var booking = new Booking
            {
                BookingId = bookingId,
                FlightId = 1,
                PassengerId = 1,
                IsCheckedIn = false,
                ReservationDate = DateTime.UtcNow
            };
            await _bookingRepo.CreateBookingAsync(booking);

            // Act
            var (success, message, boardingPass) = await _checkInService.AssignSeatToBookingAsync(bookingId, seatId);

            // Assert
            Assert.IsFalse(success);
            Assert.IsTrue(message.Contains("Seat not found"));
            Assert.IsNull(boardingPass);
        }
    }
}