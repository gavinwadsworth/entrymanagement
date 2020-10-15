using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using APIGateway.Models;
using APIGateway.Data;
using System.Text.Json;
using System.Net.Http;
using System;
using APIGateway.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace APIGateway
{
    [Route("api/kiosk")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class KioskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<KioskController> _logger;

        public KioskController(IMapper mapper, ILogger<KioskController> logger)
        {
            _mapper = mapper;
            _logger = logger;

            ApiClientHelper.Init();

            //ApiClientHelper.GetTokenAsync().GetAwaiter().GetResult();
        }

        [HttpGet]
        [HttpGet("{id:int}")]
        public ActionResult Default()
        {
            return NotFound();
        }

        [HttpGet("{emailAddress}")]
        // TO DO: Implement a retry pattern / circuit breaker pattern
        public async Task<AppointmentViewModelReadDTO> GetAppointmentDetailsAsync(string emailAddress)
        {
            Visitor visitor = await GetVisitorAsync(emailAddress);

            Appointment appointment = await GetAppointmentAsync(visitor.Id);

            Employee employee = await GetEmployeeAsync(appointment.EmployeeId);

            // Apply mappings
            var appointmentModel = _mapper.Map<AppointmentReadDTO>(appointment);
            var visitorModel = _mapper.Map<VisitorReadDTO>(visitor);
            var employeeModel = _mapper.Map<EmployeeReadDTO>(employee);

            var model = new AppointmentViewModelReadDTO()
            {
                Title = appointmentModel.Title,
                StartTime = appointmentModel.StartTime,
                FinishTime = appointmentModel.FinishTime,
                VisitorFullName = visitorModel.FullName,
                EmployeeFullName = employeeModel.FullName
            };

            //_logger.LogInformation("Successfully loaded the appointment for {email} at {time}.", model.EmailAddress, DateTime.UtcNow);

            return model;
        }

        // Supporting methods that cannot be called directly through the API.

        [NonAction]
        public async Task<Appointment> GetAppointmentAsync(int id)
        {
            // Set the naming policy to camel case so deserialized JSON can be mapped to models.
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string url = $"https://localhost:44357/api/appointments/" + id;

            using (HttpResponseMessage response = await ApiClientHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Appointment appointment = await JsonSerializer.DeserializeAsync<Appointment>(await response.Content.ReadAsStreamAsync(), options);

                    return appointment;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        [NonAction]
        public async Task<Visitor> GetVisitorAsync(string emailAddress)
        {
            string visitorApiUrl = $"https://localhost:44379/api/visitors/" + emailAddress;

            //Set the naming policy to camel case so deserialized JSON can be mapped to models.
            var settings = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            using (HttpResponseMessage visitorResponse = await ApiClientHelper.ApiClient.GetAsync(visitorApiUrl))
            {
                if (visitorResponse.IsSuccessStatusCode)
                {
                    Visitor visitor = await JsonSerializer.DeserializeAsync<Visitor>(await visitorResponse.Content.ReadAsStreamAsync(), settings);

                    return visitor;
                }
                else
                {
                    throw new Exception(visitorResponse.ReasonPhrase);
                }
            }
        }

        [NonAction]
        public async Task<Visitor> GetVisitorByIdAsync(int id)
        {
            string visitorApiUrl = $"https://localhost:44379/api/visitors/" + id;

            //Set the naming policy to camel case so deserialized JSON can be mapped to models.
            var settings = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            using (HttpResponseMessage visitorResponse = await ApiClientHelper.ApiClient.GetAsync(visitorApiUrl))
            {
                if (visitorResponse.IsSuccessStatusCode)
                {
                    Visitor visitor = await JsonSerializer.DeserializeAsync<Visitor>(await visitorResponse.Content.ReadAsStreamAsync(), settings);

                    return visitor;
                }
                else
                {
                    throw new Exception(visitorResponse.ReasonPhrase);
                }
            }
        }

        [NonAction]
        public async Task<Employee> GetEmployeeAsync(int id)
        {
            string employeeApiUrl = $"https://localhost:44313/api/employees/" + id;

            //Set the naming policy to camel case so deserialized JSON can be mapped to models.
            var settings = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            using (HttpResponseMessage employeeResponse = await ApiClientHelper.ApiClient.GetAsync(employeeApiUrl))
            {
                if (employeeResponse.IsSuccessStatusCode)
                {
                    Employee employee = await JsonSerializer.DeserializeAsync<Employee>(await employeeResponse.Content.ReadAsStreamAsync(), settings);

                    return employee;
                }
                else
                {
                    throw new Exception(employeeResponse.ReasonPhrase);
                }
            }
        }

        [HttpGet]
        [Route("api/appointments")]


        // Note to self: Could this be refactored by searching the appointment api by date?
        // Or having the appointment api do the calculation before sending todays appointments?

        public async Task<List<AppointmentViewModelReadDTO>> GetAppointmentsAsync()
        {
            // Set the naming policy to camel case so deserialized JSON can be mapped to models.
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string url = $"https://localhost:44357/api/appointments/";

            // Empty appointment list that will be populated
            List<AppointmentViewModelReadDTO> appointmentList = new List<AppointmentViewModelReadDTO>();

            using (HttpResponseMessage response = await ApiClientHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<AppointmentViewModelReadDTO> appointments = await JsonSerializer.DeserializeAsync<List<AppointmentViewModelReadDTO>>(await response.Content.ReadAsStreamAsync(), options);

                    foreach (AppointmentViewModelReadDTO appointment in appointments)
                    {

                        appointmentList.Add(appointment);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            return appointmentList;
        }

    }
}
