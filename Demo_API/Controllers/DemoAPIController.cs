using Demo_API.Data;
using Demo_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API.Controllers
{
    [Route("api/DemoAPI")]
    [ApiController]
    public class DemoAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<DemoAPIController> _logger;
        public DemoAPIController(ILogger<DemoAPIController>logger, ApplicationDbContext db)
        {
            _logger = logger;

            _db = db;   

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PersonDTO>> GetPerson()
        {
            _logger.LogInformation("Getting all People!!");
            return Ok( _db.People.ToList());
        }

        [HttpGet("{id:int}", Name ="GetPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PersonDTO> GetPerson(int id)
        {
            _logger.LogError("Get person error with id ="+id);
               
            
           var  person = _db.People.FirstOrDefault(u => u.Id == id);
            if (person==null)
            {
                return NotFound();
            }
            return Ok( person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PersonDTO> CreatePerson([FromBody]PersonDTO personDTO)
        {
            if(personDTO.Id == null) {
                return BadRequest(personDTO);
            }

           


            Person model = new()
            {
                Id=personDTO.Id,
                Name=personDTO.Name,
                Age=personDTO.Age,
                Address=personDTO.Address,
                ImageUrl=personDTO.ImageUrl,    
            
            };

            _db.People.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetPerson", new {id= personDTO.Id} , personDTO);
        }


        [HttpDelete("{id:int}", Name ="DeletePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePerson(int id)
        {
            if(id == 0) { 
                return StatusCode( StatusCodes.Status400BadRequest);
            }

            var person = _db.People.FirstOrDefault(u => u.Id == id);

            if(person==null) {
                return NotFound();
            } 

           _db.People.Remove(person);
            _db.SaveChanges();
            return NoContent();

        }


        [HttpPut("{id:int}",Name ="UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePerson(int id,PersonDTO personDTO) { 
        
            if(personDTO == null ||id!= personDTO.Id ) { return StatusCode( StatusCodes.Status400BadRequest);}

            Person model = new()
            {
                Id = personDTO.Id,
                Name = personDTO.Name,
                Age = personDTO.Age,
                Address = personDTO.Address,
                ImageUrl = personDTO.ImageUrl,

            };
            _db.People.Update(model);
            _db.SaveChanges();
            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePartialPerson(int id,JsonPatchDocument<PersonDTO> PatchDTO) {

            if (PatchDTO == null || id == 0) {
                return BadRequest();
            }
            var person = _db.People.FirstOrDefault(p => p.Id == id);

            if (person == null) { return BadRequest(); }

            PersonDTO personDTO = new() { 
            Id = person.Id,
            Name = person.Name,
            Age = person.Age,   
            Address = person.Address,   
            ImageUrl = person.ImageUrl, 
            };

            PatchDTO.ApplyTo(personDTO, ModelState);   
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Person model = new()
            {
                Id = personDTO.Id,
                Name = personDTO.Name,
                Age = personDTO.Age,
                Address = personDTO.Address,
                ImageUrl = personDTO.ImageUrl,

            };
            _db.People.Update(model);  
            _db.SaveChanges();
            return NoContent() ;
        }


    }
}
