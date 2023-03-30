using EvaluacionApi.Context;
using EvaluacionApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public UsuarioController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return context.Usuario.Include(x => x.servicio).ToList();
        }
        [HttpGet("{id}", Name = "ObtenerUsuario")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = context.Usuario.Include(x => x.servicio).FirstOrDefault(x => x.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            context.Usuario.Add(usuario);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerUsuario", new { id = usuario.Id }, usuario);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            context.Entry(usuario).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Usuario> Delete(int id)
        {
            var usuario = context.Usuario.FirstOrDefault(x => x.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            context.Usuario.Remove(usuario);
            context.SaveChanges();
            return usuario;
        }
    }
}
