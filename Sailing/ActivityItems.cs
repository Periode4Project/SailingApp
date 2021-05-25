using System;
using System.Collections.Generic;
using System.Text;

namespace Sailing
{
    public class ActivityItems
    {
        public static IEnumerable<ActivityItem> Get()
        {
            return new List<ActivityItem>
            {
                new ActivityItem()
                {
                    ActivityName = "ass",
                    ActivityDesc = "ass",
                    ActivityLocation = "ass",
                    ActivityImage = "buttocks",
                    ActivityType = "Bollocks",
                    EntranceFee = 12
                },
                new ActivityItem()
                {
                    ActivityName = "ass2",
                    ActivityDesc = "ass2",
                    ActivityLocation = "ass2",
                    ActivityImage = "buttocks2",
                    ActivityType = "Bollocks2",
                    EntranceFee = 122
                },
                new ActivityItem()
                {
                    ActivityName = "ass3",
                    ActivityDesc = "ass3",
                    ActivityLocation = "ass3",
                    ActivityImage = "buttocks3",
                    ActivityType = "Bollocks3",
                    EntranceFee = 123
                },
                new ActivityItem()
                {
                    ActivityName = "ass4",
                    ActivityDesc = "ass4",
                    ActivityLocation = "ass4",
                    ActivityImage = "buttocks4",
                    ActivityType = "Bollocks4",
                    EntranceFee = 124
                }
            };
        }
    }
}
