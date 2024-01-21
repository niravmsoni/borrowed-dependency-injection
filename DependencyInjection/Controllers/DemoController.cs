using DependencyInjection.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DependencyInjection.Controllers
{
    [Route("api/demo")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        [ServiceFilter(typeof(MyServiceFilterAttribute))]
        public ActionResult GetAll()
        {
            return Ok(nameof(GetAll));
        }

        [HttpGet("{id:int:min(1)}")]
        public ActionResult GetById(int id)
        {
            if (id == 2)
                return NotFound($"No resource found for Id - {id}");

            if (id == 1)
                throw new System.Exception();

            return Ok($"{nameof(GetById)} - {id}");
        }

        [HttpGet("file")]
        public ActionResult GetFile() 
        {
            return File(new byte[] { },"application/pdf","test.pdf");
        }

        [HttpGet("string")]
        public string Getstring()
        {
            return "string";
        }

        [HttpPost]
        public ActionResult Create(CreateDemoDto dto)
        {
            if (ModelState.IsValid)
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState.Values.First().Errors.First().ErrorMessage);
            }
        }

        [HttpPost("form")]
        public ActionResult CreateWithFile([FromForm] CreateDemoWithFileDto dto)
        {
            return Ok(dto.File.FileName);
        }

        [HttpPut]
        public ActionResult Update(CreateDemoDto dto)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }
    }

    public class CreateDemoDto
    {
        [Required(ErrorMessage = "This is my error message")]
        [MaxLength(5)]
        public string Name { get; set; }
    }

    public class CreateDemoWithFileDto
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
    }
}
