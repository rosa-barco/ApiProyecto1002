using ApiProjecto1002.Context;
using ApiProjecto1002.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProjecto1002.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Gestores : ControllerBase
    {
        private readonly AppDbContext context;

        public Gestores(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<Gestores>
        [HttpGet]

        public ActionResult Get()
        {
            try
            {
                return Ok(context.usuarios.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<Gestores>/5
        [HttpGet("{id}",Name ="Usuarios")]
        public ActionResult Get(int id)
        {
            try
            {
                var usuer = context.usuarios.FirstOrDefault(x => x.Id == id);
                return Ok(User);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/<Gestores>
        [HttpPost]

        public ActionResult Post([FromBody] usuarios user)
        {
            try
            {
                context.usuarios.Add(user);
                context.SaveChanges();
                return CreatedAtRoute("Usuarios", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Gestores>/5
        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] usuarios user)
        {
            try
            {
                if (user.Id == id)
                {
                    context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtAction("Usuarios", new { id = user.Id }, user);
;
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<Gestores>/5
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            try
            {
                var user = context.usuarios.FirstOrDefault(x => x.Id == id);
                if (user !=  null)
                {
                    context.usuarios.Remove(user);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
