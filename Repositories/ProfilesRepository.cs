using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FriendZone.Models;

namespace FriendZone.Repositories
{
 public class ProfilesRepository 
 {
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Profile> Get()
  {
   string sql = @"
    SELECT
     a.*
     p.*
     FROM profiles p
     JOIN accounts a ON g.creatorId = a.id
   ";
   return _db.Query<Account, Profile, Profile>(sql, (a, p) =>
   {
    p.Creator = a;
    return p;
   }).ToList();
  }

  internal Profile Create(Profile profile)
  {
   string sql = @"
   INSERT INTO profiles
   (name, picture, likes, creatorId)
   VALUES(@Name, @Picture, @Likes, @CreatorId);
   SELECT LAST_INSERT_ID();
   ";
   int id = _db.ExecuteScalar<int>(sql, profile);
   profile.Id = id;
   return profile;
  }
 }
}