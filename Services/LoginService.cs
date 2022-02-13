using AppMauiBlazorLoginJwt.Helpers;
using AppMauiBlazorLoginJwt.Interfaces;
using AppMauiBlazorLoginJwt.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppMauiBlazorLoginJwt.Services
{
    public class LoginService : ILogin
    {
        System.Net.Http.HttpClient client;
        string WebAPIUrl = string.Empty;
        public LoginService()
        {
            client = new System.Net.Http.HttpClient();
        }

        public async Task<AppMauiBlazorLoginJwt.Models.Login> Authenticate(UserMin user)
        {
            await Task.Delay(1000);
            user.Password = Functions.GetSHA256(user.Password).ToUpper();


            //WebAPIUrl = "http://189.254.239.133/LoginAppApi/api/login/autenticar";
            WebAPIUrl = "https://localhost:44321/api/auth/login";

            //Con esta Api de ejemplo hice la prueba
            //WebAPIUrl = "https://ej2services.syncfusion.com/production/web-services/api/Orders"; 
            var uri = new Uri(WebAPIUrl);
            try
            {
                HttpContent _content = new StringContent(JsonConvert.SerializeObject(user));
                _content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PostAsync(uri, _content);

                if (response.IsSuccessStatusCode)
                {
                    AppMauiBlazorLoginJwt.Models.Login _login = new AppMauiBlazorLoginJwt.Models.Login();
                    var content = await response.Content.ReadAsStringAsync();
                    _login = JsonConvert.DeserializeObject<AppMauiBlazorLoginJwt.Models.Login>(content);
                    return _login;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return null;
        }

    }
}
