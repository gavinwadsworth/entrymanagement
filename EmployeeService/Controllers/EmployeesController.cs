using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmployeeService.Data;
using EmployeeService.DTOs;
using EmployeeService.Models;
using Microsoft.AspNetCore.Authorization;


namespace EmployeeService.Controllers
{
    // Inherit from ControllerBase as API doesn't require a view.
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // Load the dependencies
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        // Inject the dependencies
        public EmployeesController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET /api/employees
        //[Authorize]
        [HttpGet]
        public ActionResult <IEnumerable<EmployeeReadDTO>> GetEmployees()
        {
            var employees = _repository.GetEmployees();

            if (employees != null)
            {
                return Ok(_mapper.Map<List<EmployeeReadDTO>>(employees));
            }
            else
            {
                return NotFound();
            }
            
        }
        // GET /api/employees/{id}
        //[Authorize]
        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult<EmployeeReadDTO> GetEmployee(int id)
        {
            var employee = _repository.GetEmployee(id);
            if (employee != null)
            {
                return Ok(_mapper.Map<EmployeeReadDTO>(employee));
            }
            else
            {
                return NotFound();
            }
        }
        // POST api/employees
        //[Authorize]
        [HttpPost]
        public ActionResult<EmployeeReadDTO> CreateEmployee(EmployeeCreateDTO employeeCreateDTO)
        {
            var model = _mapper.Map<Employee>(employeeCreateDTO);
            _repository.CreateEmployee(model);
            _repository.SaveChanges();
            var employeeReadDTO = _mapper.Map<EmployeeReadDTO>(model);
            // Pass back the URI of the newly created resource.
            return CreatedAtRoute(nameof(GetEmployee), new { Id = employeeReadDTO.Id }, employeeReadDTO);
        }
        // PUT api/employees/{id}
        //[Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDTO)
        {
            var model = _repository.GetEmployee(id);
            if (model == null)
            {
                return NotFound();
            }
            _mapper.Map(employeeUpdateDTO, model);
            _repository.UpdateEmployee(model);
            _repository.SaveChanges();
            return NoContent();
        }
        // PATCH api/employees/{id}
        //[Authorize]
        [HttpPatch("{id}")]
        public ActionResult PartialEmployeeUpdate(int id, JsonPatchDocument<EmployeeUpdateDTO> patchDocument)
        {
            var model = _repository.GetEmployee(id);
            if (model == null)
            {
                return NotFound();
            }

            var employeeToPatch = _mapper.Map<EmployeeUpdateDTO>(model);
            patchDocument.ApplyTo(employeeToPatch, ModelState);

            if (!TryValidateModel(employeeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeeToPatch, model);
            _repository.UpdateEmployee(model);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE /api/employees{id}
        //[Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var model = _repository.GetEmployee(id);

            if (model == null)
            {
                return NotFound();
            }

            _repository.DeleteEmployee(model);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
