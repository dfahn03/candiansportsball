using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using canadiansportsball.Models;
using canadiansportsball.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace canadiansportsball.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamRepository _repo;
        public TeamsController(TeamRepository repo)
        {
            _repo = repo;
        }
        // GET api/teams
        [HttpGet]
        public ActionResult<IEnumerable<Team>> Get()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/teams/5
        [HttpGet("{id}")]
        public ActionResult<Team> Get(int id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/teams
        [HttpPost]
        public ActionResult<Team> Post([FromBody] Team value)
        {
            try
            {
                return Ok(_repo.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/teams/5
        [HttpPut("{id}")]
        public ActionResult<Team> Put(int id, [FromBody] Team value)
        {
            try
            {
                value.Id = id;
                return Ok(_repo.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/teams/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_repo.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
