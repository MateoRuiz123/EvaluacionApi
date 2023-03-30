using EvaluacionApi.Context;
using EvaluacionApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ServicioController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Servicio>> Get()
        {
            return context.Servicio.Include(x => x.Usuarios).ToList();
        }

        [HttpGet("{id}", Name = "ObtenerServicio")]
        public ActionResult<Servicio> Get(int id)
        {
            var servicio = context.Servicio.Include(x => x.Usuarios).FirstOrDefault(x => x.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }
            return servicio;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Servicio servicio)
        {
            context.Servicio.Add(servicio);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerServicio", new { id = servicio.Id }, servicio);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Servicio servicio)
        {
            if (id != servicio.Id)
            {
                return BadRequest();
            }
            context.Entry(servicio).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Servicio> Delete(int id)
        {
            var servicio = context.Servicio.FirstOrDefault(x => x.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }
            context.Servicio.Remove(servicio);
            context.SaveChanges();
            return servicio;
        }
    }
}
