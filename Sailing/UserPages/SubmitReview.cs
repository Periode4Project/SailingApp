using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sailing.configuration;

namespace Sailing
{
    public static class SubmitReview
    {
        public static async Task<bool> IsSuccessful(string reviewTitle, string review, double rating, int activity)
        {
            Config.Read();
            if (!await Auth.CheckIsValidLogin(writecfg: false))
                return false;
            return await IsWebrequestSuccessful(reviewTitle, review, rating, activity);
        }

        public async static Task<bool> IsWebrequestSuccessful(string reviewTitle, string review, double rating, int activity)
        {
            
            HttpClient httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(new
            {
                reviewID = 0,
                reviewTitle = reviewTitle,
                rating = rating,
                reviewDESC = review,
                reviewWriter = 0,
                reviewWriterName = "",
                loginUserCredentials = new
                {
                    email = Config.User.Email,
                    password = Config.User.Password
                }
            });
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://64.40.9.86:25832/Reviews/AddReview")
            };
            try
            {
                HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
