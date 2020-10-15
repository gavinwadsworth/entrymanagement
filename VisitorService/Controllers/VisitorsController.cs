using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VisitorService.Data;
using VisitorService.DTOs;
using VisitorService.Models;
using Microsoft.AspNetCore.Authorization;
using System;

namespace VisitorService.Controllers
{
    // Inherit from ControllerBase as API doesn't require a view.
    [Route("api/visitors")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorRepository _repository;
        private readonly IMapper _mapper;

        public VisitorsController(IVisitorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET /api/visitors
        //[Authorize]
        [HttpGet]
        public ActionResult <IEnumerable<VisitorReadDTO>> GetVisitors()
        {
            var visitors = _repository.GetVisitors();

            if (visitors != null)
            {
                return Ok(_mapper.Map<List<VisitorReadDTO>>(visitors));
            }
            else
            {
                return NotFound(null);
            }
        }
        // GET /api/visitors/{id}
        //[Authorize]
        [HttpGet("{id:int}", Name ="GetVisitor")]
        public ActionResult<VisitorReadDTO> GetVisitor(int id)
        {
            var visitor = _repository.GetVisitor(id);

            if (visitor != null)
            {
                return Ok(_mapper.Map<VisitorReadDTO>(visitor));
            }
            else
            {
                return NotFound();
            }
        }
        // GET /api/visitors/{emailAddress}
        [HttpGet("{emailAddress}")]
        public ActionResult<VisitorReadDTO> GetVisitorByEmail(string emailAddress)
        {
            var visitor = _repository.GetVisitorByEmail(emailAddress);

            if (visitor != null)
            {
                return Ok(_mapper.Map<VisitorReadDTO>(visitor));
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/visitors
        //[Authorize]
        [HttpPost]
        public ActionResult <VisitorReadDTO> CreateVisitor(VisitorCreateDTO visitorCreateDTO)
        {
            var model = _mapper.Map<Visitor>(visitorCreateDTO);
            _repository.CreateVisitor(model);
            _repository.SaveChanges();
            var visitorReadDTO = _mapper.Map<VisitorReadDTO>(model);
            // Pass back the URI of the newly created resource.
            return CreatedAtRoute(nameof(GetVisitor), new { Id = visitorReadDTO.Id }, visitorReadDTO);
        }
        // PUT api/visitors/{id}
        //[Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateVisitor(int id, VisitorUpdateDTO visitorUpdateDTO)
        {
            var model = _repository.GetVisitor(id);
            if (model == null)
            {
                return NotFound();
            }
            _mapper.Map(visitorUpdateDTO, model);
            _repository.UpdateVisitor(model);
            _repository.SaveChanges();
            return NoContent();
        }
        // PATCH api/visitors/{id}
        //[Authorize]
        [HttpPatch("{id}")]
        public ActionResult PartialVisitorUpdate(int id, JsonPatchDocument<VisitorUpdateDTO> patchDocument)
        {
            var model = _repository.GetVisitor(id);
            if (model == null)
            {
                return NotFound();
            }

            var visitorToPatch = _mapper.Map<VisitorUpdateDTO>(model);
            patchDocument.ApplyTo(visitorToPatch, ModelState);

            if (!TryValidateModel(visitorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(visitorToPatch, model);
            _repository.UpdateVisitor(model);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE /api/visitors{id}
        //[Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteVisitor(int id)
        {
            var model = _repository.GetVisitor(id);

            if (model == null)
            {
                return NotFound();
            }

            _repository.DeleteVisitor(model);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}