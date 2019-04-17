using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    public Keep GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @Id", new { Id });
    }

    public Keep CreateKeep(Keep keepToCreate)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO keeps (name, description, userId, img, isPrivate)
                    VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
                    SELECT LAST_INSERT_ID();
                ", keepToCreate);
        keepToCreate.Id = id;
        return keepToCreate;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    internal IEnumerable<Keep> GetByUserId(string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM keeps WHERE userId = @userId", new { userId });
    }

    public Keep EditKeep(int id, Keep editedKeep)
    {
      try
      {
        string query = @"
                UPDATE keeps SET
                    name = @editedKeep.Name,
                    description = @editedKeep.Description,
                    userId = @editedKeep.UserId,
                    img = @editedKeep.Img,
                    keeps = @editedKeep.Keeps,
                    isPrivate = @editedKeep.IsPrivate,
                    shares = @editedKeep.Shares,
                    views = @editedKeep.Views

                WHERE id = @id;
                SELECT * FROM keeps WHERE id = @id;
                ";
        return _db.QueryFirstOrDefault<Keep>(query, new { id, editedKeep });
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }

    }

    public bool Delete(int id, string userId)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @id AND userId = @userId", new { id, userId });
      return success > 0;
    }
  }
}