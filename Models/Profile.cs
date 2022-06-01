using System;
using System.Collections.Generic;

namespace FriendZone.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Likes { get; set; }
        public Account Creator { get; set; }
        public string CreatorId { get; set; }
 }
}