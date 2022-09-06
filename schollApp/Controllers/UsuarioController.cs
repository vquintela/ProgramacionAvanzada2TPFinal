using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schollApp.Context;
using schollApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schollApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDBContext context;

        public UsuarioController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult Get()
        {
           try
            {
                return Ok(context.usuario.ToList());
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}", Name = "usuarioId")]
        public ActionResult Get(int id)
        {
            try
            {
                var usuario = context.usuario.Find(id);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                context.usuario.Add(usuario);
                context.SaveChanges();
                return CreatedAtRoute("usuarioId", new { id = usuario.id_usuario }, usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.id_usuario == id)
                {
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("usuarioId", new { id = usuario.id_usuario }, usuario);
                } else
                {
                    return BadRequest("Id incorrecto");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var usuario = context.usuario.Find(id);
                if (usuario != null)
                {
                    context.usuario.Remove(usuario);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest("Id incorrecto");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
