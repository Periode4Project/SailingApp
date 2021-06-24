using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sailing
{
    public class ActivityItems
    {
        /// <summary>
        /// haalt alle activities op van de API en geeft ze terug in een lijst
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ActivityItem>> GetAsync()
        {
            try
            {
                string url = @"http://64.40.9.86:25832/Activities/GetAll";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<List<ActivityItem>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<ActivityItem>
                {
                    new ActivityItem
                    {
                        ActivityId = 0,
                        ActivityName = "Error",
                        ActivityDesc = e.Message,
                        ActivityImage = "https://www.pasadenalawgroup.com/wp-content/uploads/2018/11/ThinkstockPhotos-627455048-1.jpg",
                        ActivityPlace = new Place
                        {
                            Address = "error",
                            City = "error",
                            Location = new Locations
                            {
                                lat = 0,
                                lng = 0
                            }
                        },
                        ActivityType = "error",
                        EntranceFee = 0
                    }
                };
            }
            
        }

        public static List<ActivityItem> Get()
        {
            return GetAsync().Result;
        }
    }
}
