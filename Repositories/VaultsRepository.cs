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

    // public Vault EditVault(int id, Vault editedVault)
    // {
    //   try
    //   {
    //     string query = @"
    //             UPDATE keeps SET
    //                 name = @editedVault.Name,
    //                 description = @editedVault.Description,
    //                 userId = @editedVault.UserId,
    //                 img = @editedVault.Img
    //             WHERE id = @Id;
    //             SELECT * FROM keeps WHERE id = @Id;
    //             ";
    //     return _db.QueryFirstOrDefault<Vault>(query, new { id, editedVault });
    //   }
    //   catch (Exception e)
    //   {
    //     Console.WriteLine(e);
    //     return null;
    //   }

    // }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return success > 0;
    }
  }
}