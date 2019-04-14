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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _vkr;
    public VaultKeepsController(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<VaultKeep>> Get()
    {
      IEnumerable<VaultKeep> results = _vkr.GetALL();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //GETBYID
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> Get(int id)
    {
      VaultKeep found = _vkr.GetById(id);
      if (found == null) { return BadRequest(); }
      return Ok(found);
    }

    //GetAllKeepsInVaultKeep
    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetKeeps(int id)
    {
      IEnumerable<Keep> results = _vkr.GetKeeps(id);
      return Ok(results);
    }

    //CREATE
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultKeep)
    {
      VaultKeep newVaultKeep = _vkr.CreateVaultKeep(vaultKeep);
      if (newVaultKeep == null) { return BadRequest("haters gonna hate"); }
      return Ok(newVaultKeep);
    }

    //EDIT
    [HttpPut("{id}")]
    public ActionResult<VaultKeep> Edit(int id, [FromBody] VaultKeep editedVaultKeep)
    {
      VaultKeep updatedVaultKeep = _vkr.EditVaultKeep(id, editedVaultKeep);
      if (updatedVaultKeep == null) { return BadRequest("haters gonna hate"); }
      return Ok(updatedVaultKeep);
    }

    //DELETE
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vkr.Delete(id);
      if (!successful) { return BadRequest(); }
      return Ok();
    }

  }
}