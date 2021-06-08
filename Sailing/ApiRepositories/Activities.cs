using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sailing.ApiRepositories
{
    public static class Activities
    {
        static readonly string baseURL = "";
        public static List<ActivityItem> GetAllActivities()
        {
            try
            {
                string url = "http://64.40.9.86:25832/Activities/GetAllActivities";
                HttpClient http = new HttpClient();
                string httpResponse = http.GetStringAsync(url).Result;
                List<ActivityItem> activityItems = JsonConvert.DeserializeObject<List<ActivityItem>>(httpResponse);
                return activityItems;
            }
            catch (Exception e)
            {
                return new List<ActivityItem>()
                {
                    new ActivityItem
                    {
                        ActivityDesc = e.Message,
                        ActivityPlace = new Place
                        {
                            City = "",
                            Address = "",
                            Location = new Location
                            {
                                lat = 0,
                                lng = 0
                            }
                        }
                    }
                };
            }
        }
    }
}