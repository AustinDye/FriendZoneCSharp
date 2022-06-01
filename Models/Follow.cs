namespace FriendZone.Models
{
 public class Follow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public Profile Follower { get; set; }

        public string FollowerId { get; set; }
 }
}