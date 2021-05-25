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
                    ActivityImage = "https://i.imgur.com/ZvHy6WW.png",
                    ActivityType = "Bollocks",
                    EntranceFee = 12
                },
                new ActivityItem()
                {
                    ActivityName = "ass2",
                    ActivityDesc = "ass2",
                    ActivityLocation = "ass2",
                    ActivityImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcjKj21zz8YWR41XrXuOp04CpScM2_G2bdcg&usqp=CAU",
                    ActivityType = "Bollocks2",
                    EntranceFee = 122
                },
                new ActivityItem()
                {
                    ActivityName = "ass3",
                    ActivityDesc = "ass3",
                    ActivityLocation = "ass3",
                    ActivityImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRsZvl-UyKvoxSC0d0hiHgiy7tVZ6PV4QHSfw&usqp=CAU",
                    ActivityType = "Bollocks3",
                    EntranceFee = 123
                },
                new ActivityItem()
                {
                    ActivityName = "ass4",
                    ActivityDesc = "ass4",
                    ActivityLocation = "ass4",
                    ActivityImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS4ieAbD_WnmAIKp-TzeBPPvkL55BtJtJaK3w&usqp=CAU",
                    ActivityType = "Bollocks4",
                    EntranceFee = 124
                }
            };
        }
    }
}
