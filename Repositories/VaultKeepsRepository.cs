using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<VaultKeep> GetALL()
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultKeeps");
    }

    public VaultKeep GetById(int Id)
    {
      return _db.QueryFirstOrDefault<VaultKeep>("SELECT * FROM vaultKeeps WHERE id = @Id", new { Id });
    }

    public VaultKeep CreateVaultKeep(VaultKeep vaultKeep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultKeeps (team1Id, team2Id)
                    VALUES (@Team1Id, @Team2Id);
                    SELECT LAST_INSERT_ID();
                ", vaultKeep);
        vaultKeep.Id = id;
        return vaultKeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public VaultKeep EditVaultKeep(int id, VaultKeep editedVaultKeep)
    {
      try
      {
        string query = @"
                UPDATE vaultKeeps SET
                    team1Id = @editedVaultKeep.Team1Id,
                    team2Id = @editedVaultKeep.Team2Id
                WHERE id = @id;
                SELECT * FROM vaultKeeps WHERE id = @id;
                ";
        return _db.QueryFirstOrDefault<VaultKeep>(query, new { id, editedVaultKeep });
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }

    }

    internal IEnumerable<Keep> GetKeeps(int id)
    {
      return _db.Query<Keep>(@"
            SELECT * 
	            FROM keeps k
	            JOIN vaultKeeps g 
		            ON p.teamId = g.team1Id 
		            OR p.teamId = g.team2Id
	            WHERE g.id = @id
            ", new { id });
    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaultKeeps WHERE id = @id", new { id });
      return success > 0;
    }
  }
}