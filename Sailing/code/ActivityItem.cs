using System;
using System.Collections.Generic;
using System.Text;

namespace Sailing
{
    public class ActivityItem
    {
        public int ActivityId { get; set; }
        public string ActivityImage { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDesc { get; set; }
        public string ActivityType { get; set; }
        public Place ActivityPlace { get; set; }
        public float EntranceFee { get; set; }
    }
    public class Place
    {
        public string City { get; set; }
        public string Address { get; set; }
        public Locations Location { get; set; }
    }

    public class Locations
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }
}
