using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _vr;
    public VaultsController(VaultsRepository vr)
    {
      _vr = vr;
    }

    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Vault> results = _vr.GetAll(userId);
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //GETBYID
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault found = _vr.GetById(id);
      if (found == null) { return BadRequest(); }
      return Ok(found);
    }

    //CREATE
    [HttpPost]
    [Authorize]
    public ActionResult<Vault> Create([FromBody] Vault vaultToCreate)
    {
      vaultToCreate.UserId = HttpContext.User.Identity.Name;
      Vault newVault = _vr.CreateVault(vaultToCreate);
      if (newVault == null) { return BadRequest("Can't create that vault"); }
      return Ok(newVault);
    }

    // EDIT
    [HttpPut("{id}")]
    public ActionResult<Vault> Edit(int id, Vault editedVault)
    {
      Vault updatedVault = _vr.EditVault(id, editedVault);
      if (updatedVault == null) { return BadRequest("can't edit that vault"); }
      return Ok(updatedVault);
    }

    //DELETE
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      var userId = HttpContext.User.Identity.Name;
      bool successful = _vr.Delete(id, userId);
      if (!successful) { return BadRequest(); }
      return Ok();
    }

    //vaultkeeps
    [HttpPost("{vaultId}")]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultKeepToCreate)
    {
      vaultKeepToCreate.UserId = HttpContext.User.Identity.Name;
      VaultKeep newVaultKeep = _vr.CreateVaultKeep(vaultKeepToCreate);
      if (vaultKeepToCreate == null) { return BadRequest("Can't add that keep to this vault"); }
      return Ok(newVaultKeep);
    }

    [HttpGet("{vaultId}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetVaultKeeps(int vaultId)
    {
      var userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> found = _vr.GetVaultKeeps(vaultId, userId);
      if (found == null) { return BadRequest(); }
      return Ok(found);
    }
  }
}