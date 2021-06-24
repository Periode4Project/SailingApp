using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sailing.admin
{
    public static class ReviewDeletion
    {
        public async static Task<bool> IsDeleteReviewSuccessful(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(Config.User), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"http://64.40.9.86:25832/Admin/DeleteReview?review={id}")
            };
            try
            {
                await httpClient.SendAsync(httpRequestMessage);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
