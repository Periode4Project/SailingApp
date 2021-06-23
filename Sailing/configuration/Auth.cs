using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sailing.configuration
{
    public static class Auth
    {
        public async static Task<bool> CheckIsValidLogin(bool writecfg)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(Config.User), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://64.40.9.86:25832/Auth/Login")
            };
            try
            {
                HttpResponseMessage response  = await httpClient.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return false;
            }
            if (writecfg)
                Config.Write();
            return true;
        }

        public async static Task<bool> CheckIsUserAdmin()
        {
            if (!await CheckIsValidLogin(writecfg: false))
                return false;
            HttpClient httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(new { email = Config.User.Email });
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://64.40.9.86:25832/Auth/IsUserAdmin")
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
