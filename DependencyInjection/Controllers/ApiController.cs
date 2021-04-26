using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
namespace DependencyInjection.Controllers
{
    //At server side, an incoming request may have an entity attached to it.To determine it’s type, server uses the HTTP request header Content-Type.Some common examples of content types are “text/plain”, “application/xml”, “text/html”, “application/json”, “image/gif”, and “image/jpeg”.

    //Content-Type: application/json
    //Similarly, to determine what type of representation is desired at client side, HTTP header ACCEPT is used.It will have one of the values as mentioned for Content-Type above.

    //Accept: application/json
    //Generally, if no Accept header is present in the request, the server can send pre-configured default representation type.
    [Produces("application/json", "application/xml")]
    [Consumes("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(nameof(GetAll));
        }
        [HttpGet("{id:int:min(1)}")]
        public ActionResult GetById(int id)
        {
            return Ok($"{nameof(GetById)} - {id}");
        }
        [HttpPost]
        public ActionResult Create(CreateDto dto)
        {
            return Ok(JsonSerializer.Serialize(dto));
        }
        [Consumes("multipart/form-data")]
        [HttpPost("form")]
        public ActionResult CreateWithFiles([FromForm] CreateWithFileDto dto)
        {
            return Ok(dto.File.FileName);
        }
        [HttpPut]
        public ActionResult Update(CreateDto dto)
        {
            return Ok(JsonSerializer.Serialize(dto));
        }
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            return Ok($"{nameof(Delete)} - {id}");
        }
    }
    public class CreateDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class CreateWithFileDto
    {
        public IFormFile File { get; set; }
    }
}
