using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/")]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository _repository;
        public TimeEntryController(ITimeEntryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Read(long id)
        {          
            if(_repository.Contains(id)) return Ok(_repository.Find(id));
            return NotFound();
        }
        public IActionResult Create(TimeEntry timeEntry)
        {
           var result = _repository.Create(timeEntry);

            return CreatedAtRoute("GetTimeEntry", new {id = timeEntry.Id}, result);
        }
        public IActionResult List()
        {
            return Ok(_repository.List());
        }
        public IActionResult Update(long id, TimeEntry timeEntry)
        {
            if(_repository.Contains(id)) return Ok(_repository.Update(id,timeEntry));
            return NotFound();
        }
        public IActionResult Delete(long id)
        {
            if(_repository.Contains(id))
            {
                _repository.Delete(id);
                return NoContent();
            }
         
            return NotFound();           
        }
    }
}
