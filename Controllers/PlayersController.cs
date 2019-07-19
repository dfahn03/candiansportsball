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
  public class PlayersController : ControllerBase
  {
    private readonly PlayerRepository _repo;
    public PlayersController(PlayerRepository repo)
    {
      _repo = repo;
    }
    // GET api/players
    [HttpGet]
    public ActionResult<IEnumerable<Player>> Get()
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

    // GET api/players/5
    [HttpGet("{id}")]
    public ActionResult<Player> Get(int id)
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

    // POST api/players
    [HttpPost]
    public ActionResult<Player> Post([FromBody] Player value)
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

    // PUT api/players/5
    [HttpPut("{id}")]
    public ActionResult<Player> Put(int id, [FromBody] Player value)
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

    // DELETE api/players/5
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
