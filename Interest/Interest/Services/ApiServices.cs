using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Interest.Models;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Xamarin.Forms;
using Interest.Helpers;

//"http://azuretestmc.azurewebsites.net/api/Account/Register"

namespace Interest.Services
{
    internal class ApiServices
    {
        public async Task<bool> RegisterAsync(
            string email, string password, string confirmPassword)
        {
            try
            { 
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);
                json.Replace("\\", "");

                HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                System.Diagnostics.Debug.WriteLine("json" + httpContent.ToString());
                var response = await client.PostAsync("http://azuretestmc.azurewebsites.net/api/Account/Register"
                , httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;//pop up login
            }
                System.Diagnostics.Debug.WriteLine("res" + response.ToString());
                return false;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Data" + e.Data);
                System.Diagnostics.Debug.WriteLine("Mess" + e.Message);
                System.Diagnostics.Debug.WriteLine("Source" + e.Source);
                throw;
            }
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, "http://azuretestmc.azurewebsites.net/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var JWT = await response.Content.ReadAsStringAsync();//Json Web Token

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(JWT);

            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
             var accessToken = jwtDynamic.Value<string>("access_token");

            
            //Settings.AccessTokenExpirationDate = accessTokenExpiration;

            Debug.WriteLine(accessTokenExpiration);

            Debug.WriteLine(JWT);

            return accessToken; //need to keep this access token global var
            
           //after this token 1 
        }
        //DisplayAlert("Alert", "You have been alerted", "OK");
        public async Task<List<Models.Interest>> GetInterestsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync("http://azuretestmc.azurewebsites.net/api/Interests");

            var interests = JsonConvert.DeserializeObject<List<Models.Interest>>(json);

            return interests;// + accessToken.ToString();
        }

        public async Task PostIdeaAsync(Interest.Models.Interest interest, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(interest);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://azuretestmc.azurewebsites.net/api/Interestsapi/Interests", content);
        }

    }

}
