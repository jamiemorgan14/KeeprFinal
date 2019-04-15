using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetALL()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }

    public Vault GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @Id", new { Id });
    }

    public Vault CreateVault(Vault vaultToCreate)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaults (name, description, userId)
                    VALUES (@Name, @Description, @UserId);
                    SELECT LAST_INSERT_ID();
                ", vaultToCreate);
        vaultToCreate.Id = id;
        return vaultToCreate;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public Vault EditVault(int id, Vault editedVault)
    {
      try
      {
        string query = @"
                UPDATE keeps SET
                    name = @editedVault.Name,
                    description = @editedVault.Description,
                    userId = @editedVault.UserId,
                WHERE id = @id;
                SELECT * FROM keeps WHERE id = @id;
                ";
        return _db.QueryFirstOrDefault<Vault>(query, new { id, editedVault });
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }

    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return success > 0;
    }

    public VaultKeep CreateVaultKeep(VaultKeep vaultKeepToCreate)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultKeeps (vaultId, keepId, userId)
                    VALUES (@VaultId, @KeepId, @UserId);
                    SELECT LAST_INSERT_ID();
                ", vaultKeepToCreate);
        vaultKeepToCreate.Id = id;
        return vaultKeepToCreate;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"
    SELECT * 
      FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId 
        WHERE (vaultId = @vaultId AND vk.userId = @userId) 
    ", new { vaultId, userId });
    }
  }
}