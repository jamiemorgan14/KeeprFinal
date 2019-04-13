using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _kr;
    public KeepsController(KeepsRepository kr)
    {
      _kr = kr;
    }

    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetALL();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //GETBYID
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep found = _kr.GetById(id);
      if (found == null) { return BadRequest(); }
      return Ok(found);
    }

    //CREATE
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep keepToCreate)
    {
      Keep newKeep = _kr.CreateKeep(keepToCreate);
      if (newKeep == null) { return BadRequest("Can't create that keep"); }
      return Ok(newKeep);
    }

    //EDIT
    [HttpPut("{id}")]
    public ActionResult<Keep> Edit(int id, [FromBody] Keep editedKeep)
    {
      Keep updatedKeep = _kr.EditPlayer(id, editedKeep);
      if (updatedKeep == null) { return BadRequest("haters gonna hate"); }
      return Ok(updatedKeep);
    }

    //DELETE
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _kr.Delete(id);
      if (!successful) { return BadRequest(); }
      return Ok();
    }

  }
}