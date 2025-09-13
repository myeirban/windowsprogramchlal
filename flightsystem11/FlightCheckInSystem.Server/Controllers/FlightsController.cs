﻿using FlightCheckInSystem.Business.Interfaces;
using FlightCheckInSystemCore.Models;
using FlightCheckInSystemCore.Enums;
using FlightCheckInSystem.Data.Interfaces;
using FlightCheckInSystem.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightCheckInSystem.Server.Controllers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; } = default!;
    }

    public class FlightStatusUpdateRequest
    {
        public FlightStatus Status { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightManagementService _flightService;
        private readonly ISeatRepository _seatRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IFlightHubService _flightHubService;
        private readonly ILogger<FlightsController> _logger;

        public FlightsController(
            IFlightManagementService flightService,
            ISeatRepository seatRepository,
            IFlightRepository flightRepository,
            IFlightHubService flightHubService,
            ILogger<FlightsController> logger)
        {
            _flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
            _seatRepository = seatRepository ?? throw new ArgumentNullException(nameof(seatRepository));
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
            _flightHubService = flightHubService ?? throw new ArgumentNullException(nameof(flightHubService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Flight>>>> GetFlights()
        {
            try
            {
                var flights = await _flightService.GetAllFlightsAsync();
                return Ok(new ApiResponse<IEnumerable<Flight>>
                {
                    Success = true,
                    Data = flights,
                    Message = "Flights retrieved successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving flights");
                return StatusCode(500, new ApiResponse<IEnumerable<Flight>>
                {
                    Success = false,
                    Message = "Internal server error"
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Flight>>> GetFlight(int id)
        {
            try
            {
                var flight = await _flightService.GetFlightDetailsAsync(id);
                if (flight == null)
                {
                    return NotFound(new ApiResponse<Flight>
                    {
                        Success = false,
                        Message = $"Flight with ID {id} not found"
                    });
                }

                return Ok(new ApiResponse<Flight>
                {
                    Success = true,
                    Data = flight,
                    Message = "Flight retrieved successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving flight with ID {id}");
                return StatusCode(500, new ApiResponse<Flight>
                {
                    Success = false,
                    Message = "Internal server error"
                });
            }
        }

        [HttpGet("number/{flightNumber}")]
        public async Task<ActionResult<ApiResponse<Flight>>> GetFlightByNumber(string flightNumber)
        {
            if (string.IsNullOrWhiteSpace(flightNumber))
            {
                return BadRequest(new ApiResponse<Flight>
                {
                    Success = false,
                    Message = "Flight number cannot be empty"
                });
            }

            try
            {
                var flights = await _flightService.GetAllFlightsAsync();
                var flight = flights.FirstOrDefault(f =>
                    f.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase));

                if (flight == null)
                {
                    return NotFound(new ApiResponse<Flight>
                    {
                        Success = false,
                        Message = $"Flight with number {flightNumber} not found"
                    });
                }

                return Ok(new ApiResponse<Flight>
                {
                    Success = true,
                    Data = flight,
                    Message = "Flight retrieved successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving flight with number {flightNumber}");
                return StatusCode(500, new ApiResponse<Flight>
                {
                    Success = false,
                    Message = "Internal server error"
                });
            }
        }

        [HttpGet("{id}/seats")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Seat>>>> GetFlightSeats(int id)
        {
            try
            {
                var flight = await _flightRepository.GetFlightByIdAsync(id);
                if (flight == null)
                {
                    return NotFound(new ApiResponse<IEnumerable<Seat>>
                    {
                        Success = false,
                        Message = $"Flight with ID {id} not found"
                    });
                }

                var seats = await _seatRepository.GetSeatsByFlightIdAsync(id);
                return Ok(new ApiResponse<IEnumerable<Seat>>
                {
                    Success = true,
                    Data = seats,
                    Message = "Seats retrieved successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving seats for flight ID {id}");
                return StatusCode(500, new ApiResponse<IEnumerable<Seat>>
                {
                    Success = false,
                    Message = "Internal server error"
                });
            }
        }

        [HttpPut("{id}/status")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateFlightStatus(int id, [FromBody] FlightStatusUpdateRequest request)
        {
            try
            {
                var flight = await _flightRepository.GetFlightByIdAsync(id);
                if (flight == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = $"Flight with ID {id} not found"
                    });
                }

                var updated = await _flightRepository.UpdateFlightStatusAsync(id, request.Status);
                if (!updated)
                {
                    return StatusCode(500, new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Failed to update flight status"
                    });
                }

                // BROADCAST THE STATUS UPDATE
                await _flightHubService.BroadcastFlightStatusUpdate(flight.FlightNumber, request.Status);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Flight status updated successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating status for flight ID {id}");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Internal server error"
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Flight>>> CreateFlight([FromBody] Flight flight)
        {
            try
            {
                if (flight == null)
                {
                    return BadRequest(new ApiResponse<Flight>
                    {
                        Success = false,
                        Message = "Flight data is required"
                    });
                }

                var flightId = await _flightRepository.AddFlightAsync(flight);
                var createdFlight = await _flightRepository.GetFlightByIdAsync(flightId);

                // BROADCAST THE NEW FLIGHT
                await _flightHubService.BroadcastNewFlight(createdFlight);

                return CreatedAtAction(nameof(GetFlight), new { id = flightId }, new ApiResponse<Flight>
                {
                    Success = true,
                    Data = createdFlight,
                    Message = "Flight created successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating flight");
                return StatusCode(500, new ApiResponse<Flight>
                {
                    Success = false,
                    Message = "Internal server error"
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateFlight(int id, [FromBody] Flight flight)
        {
            try
            {
                if (flight == null)
                {
                    return BadRequest(new ApiResponse<bool>
                    {
                        Success = false,
                        Message = "Flight data is required"
                    });
                }

                var existingFlight = await _flightRepository.GetFlightByIdAsync(id);
                if (existingFlight == null)
                {
                    return NotFound(new ApiResponse<bool>
                    {
                        Success = false,
                        Message = $"Flight with ID {id} not found"
                    });
                }

                // Update the flight ID to match the route parameter
                flight.FlightId = id;

                var updated = await _flightRepository.UpdateFlightAsync(flight);
                if (!updated)
                {
                    return StatusCode(500, new ApiResponse<bool>
                    {
                        Success = false,
                        Message = "Failed to update flight"
                    });
                }

                // Get the updated flight and broadcast the change
                var updatedFlight = await _flightRepository.GetFlightByIdAsync(id);
                await _flightHubService.BroadcastFlightUpdated(updatedFlight);

                return Ok(new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Flight updated successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating flight ID {id}");
                return StatusCode(500, new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Internal server error"
                });
            }
        }
    }
}