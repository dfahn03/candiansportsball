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
    public class GamesController : ControllerBase
    {
        private readonly GameRepository _repo;
        public GamesController(GameRepository repo)
        {
            _repo = repo;
        }
        // GET api/teams
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
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
        public ActionResult<DataGame> Get(int id)
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
        public ActionResult<Game> Post([FromBody] Game value)
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
        public ActionResult<Game> Put(int id, [FromBody] Game value)
        {
            try
            {
                value.Id = id;
                //evaluate and determine winner
                if (value.HomeScore > value.AwayScore)
                {
                    value.WinningTeamId = value.HomeTeamId;
                }
                else
                {
                    value.WinningTeamId = value.AwayTeamId;
                }
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
