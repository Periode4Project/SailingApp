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
                    ActivityId = 0,
                    ActivityName = "Ballorig",
                    ActivityDesc = "Overdekt spelen, springen, klimmen, klauteren, kruipen en glijden. Slecht weer buiten? Kom dan lekker binnen spelen bij de overdekte speeltuinen van Ballorig. Vanaf 1996 is Ballorig het eerste en leukste indoor speelparadijs van Nederland en Duitsland! Kinderen van 0 t/m 12 jaar kunnen in 38 vestigingen in Nederland en 4 in Duitsland, terecht voor het allerleukste dagje uit. Omdat kinderspeelparadijs Ballorig speciaal voor kinderen is, betalen ouders en begeleiders geen entree. Bovendien is Ballorig ideaal voor kinderfeestjes!",
                    ActivityLocation = "Heerenveen",
                    ActivityImage = "https://www.ballorig.nl/media/4806/ballorig-logo-png.png?width=340&height=140&mode=crop&center=0.50%2c0.50",
                    ActivityType = "Indoor Speeltuin",
                    EntranceFee = 8.50
                },
                new ActivityItem()
                {
                    ActivityId = 1,
                    ActivityName = "La Fontaine",
                    ActivityDesc = "Lekker eten en drinken in hartje centrum van Heerenveen? Dan mag u Restaurant & Lunchroom La Fontaine niet missen! Al meer dan 25 jaar lang een vertrouwd adres voor uw lunch, diner, catering of feest. Passie voor heerlijk eten en drinken garandeert een culinair hoogtepunt van uw bezoek aan Heerenveen. Daarnaast beschikt La Fontaine tevens over een uniek kinderrestaurant. Gezellig uit eten met de kinderen in hun eigen restaurant!",
                    ActivityLocation = "Heerenveen",
                    ActivityImage = "https://i.imgur.com/ElYZn0k.png",
                    ActivityType = "Restaurant",
                    EntranceFee = 0
                }
            };
        }
    }
}
