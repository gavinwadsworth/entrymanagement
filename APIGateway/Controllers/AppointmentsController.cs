using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGateway.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http;
using APIGateway.Data;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AppointmentsController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        
        public async Task<string> CreateAppointmentAsync([FromBody]Appointment appointment)
        {
            var settings = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            string url = $"https://localhost:44357/api/appointments/";

            var model = JsonSerializer.Serialize(appointment, settings);

            HttpContent content = new StringContent(model, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiClientHelper.ApiClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response.StatusCode.ToString();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        } 
    }
}
