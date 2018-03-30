using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            var response = await client.PostAsync("http://localhost:63724/api/Account/Register",content);

            return response.IsSuccessStatusCode;
        }
    }
}
