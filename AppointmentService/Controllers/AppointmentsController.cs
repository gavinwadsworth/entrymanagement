using AppointmentService.Data;
using AppointmentService.DTOs;
using AppointmentService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppointmentService.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/appointments
        //[Authorize]
        [HttpGet]
        public ActionResult <IEnumerable<AppointmentReadDTO>> GetAppointments()
        {
            var appointments = _repository.GetAppointments();

            if (appointments != null)
            {
                return Ok(_mapper.Map<List<AppointmentReadDTO>>(appointments));
            }
            else
            {
                return NotFound();
            }   
        }

        // GET api/appointments/{id}
        //[Authorize]
        [HttpGet("{id}", Name="GetAppointment")]
        public ActionResult <AppointmentReadDTO> GetAppointment(int id)
        {
            var appointment = _repository.GetAppointment(id);

            if (appointment != null)
            {
                return Ok(_mapper.Map<AppointmentReadDTO>(appointment));
            }

            return NotFound();
        }

        // POST api/appointments
        //[Authorize]
        [HttpPost]
        public ActionResult <AppointmentReadDTO> CreateAppointment(AppointmentCreateDTO appointmentCreateDTO)
        {
            var model = _mapper.Map<Appointment>(appointmentCreateDTO);
            _repository.CreatAppointment(model);
            _repository.SaveChanges();

            var appointmentReadDTO = _mapper.Map<AppointmentReadDTO>(model);

            return CreatedAtRoute(nameof(GetAppointment), new { Id = appointmentReadDTO.Id }, appointmentReadDTO);
            
        }

        // PUT api/appointments/{id}
        //[Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateAppointment(int id, AppointmentUpdateDTO appointmentUpdateDTO)
        {
            var model = _repository.GetAppointment(id);

            if (model == null)
            {
                return NotFound();
            }

            _mapper.Map(appointmentUpdateDTO, model);
            _repository.UpdateAppointment(model);
            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/appointments/{id}
        //[Authorize]
        [HttpPatch("{id}")]
        public ActionResult PartialAppointmentUpdate(int id, JsonPatchDocument<AppointmentUpdateDTO> patchDocument)
        {
            var model = _repository.GetAppointment(id);

            if (model == null)
            {
                return NotFound();
            }

            var appointmentToPatch = _mapper.Map<AppointmentUpdateDTO>(model);
            patchDocument.ApplyTo(appointmentToPatch, ModelState);

            if (!TryValidateModel(appointmentToPatch))
            {
                return ValidationProblem();
            }

            _mapper.Map(appointmentToPatch, model);
            _repository.UpdateAppointment(model);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/appointments/{id}
        //[Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteAppointment(int id)
        {
            var model = _repository.GetAppointment(id);

            if (model == null)
            {
                return NotFound();
            }

            _repository.DeleteAppointment(model);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
