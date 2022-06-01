using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FriendZone.Models;

namespace FriendZone.Repositories
{
 public class FollowsRepository 
 {
  private readonly IDbConnection _db;

  public FollowsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Follow> Get()
  {
   string sql = @"
    SELECT
     p.*
     f.*
     FROM follow f
     JOIN profiles a ON f.followerId = p.id
   ";
   return _db.Query<Profile, Follow, Follow>(sql, (p, f) =>
   {
    f.Follower = p;
    return f;
   }).ToList();
  }

  internal Follow Create(Follow follow)
  {
   string sql = @"
   INSERT INTO groups
   (name, picture, followerId)
   VALUES(@Name, @Picture, @FollowerId);
   SELECT LAST_INSERT_ID();
   ";
   int id = _db.ExecuteScalar<int>(sql, follow);
   follow.Id = id;
   return follow;
  }
 }
}