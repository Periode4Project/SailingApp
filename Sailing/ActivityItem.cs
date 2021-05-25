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
        public string ActivityLocation { get; set; }
        public double EntranceFee { get; set; }
    }
}
