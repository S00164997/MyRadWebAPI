using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Interest.Models;
using Newtonsoft.Json;


namespace Interest.Services
{
    public class ApiServices
    {//reg user
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            try
            {

                System.Diagnostics.Debug.WriteLine("Here");
                System.Diagnostics.Debug.WriteLine("Email: "+email);
                var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
         //   content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync("http://localhost:63724/api/Account/Register", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Paddy 8================)"+e);
                throw;
            }
        }
    }
}
