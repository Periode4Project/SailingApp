using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sailing.UserPages
{
    public class Reviews
    {
        /// <summary>
        /// haalt de reviews op uit de Backend
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static async Task<List<Review>> GetAsync(int activity)
        {
            try
            {
                string url = $@"http://64.40.9.86:25832/Reviews/GetReviewsForActivity?activity={activity}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<List<Review>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Review>
                {
                    new Review
                    {
                        ReviewID = 0,
                        ReviewTitle = "Error",
                        Rating = 0,
                        ReviewDESC = e.Message,
                        ReviewWriter = 0,
                        ReviewWriterName = "Error",
                        Activity = 0
                    }
                };
            }

        }

        public static List<Review> Get(int review)
        {
            return GetAsync(review).Result;
        }

        public static async Task<List<Review>> GetAsync()
        {
            try
            {
                string url = $@"http://64.40.9.86:25832/Reviews/GetAllReviews";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<List<Review>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Review>
                {
                    new Review
                    {
                        ReviewID = 0,
                        ReviewTitle = "Error",
                        Rating = 0,
                        ReviewDESC = e.Message,
                        ReviewWriter = 0,
                        ReviewWriterName = "Error",
                        Activity = 0
                    }
                };
            }

        }

        public static List<Review> Get()
        {
            return GetAsync().Result;
        }
    }
}
