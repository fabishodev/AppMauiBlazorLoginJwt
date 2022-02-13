using AppMauiBlazorLoginJwt.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMauiBlazorLoginJwt.Services
{
    public class ProductService : IProduct
    {
        System.Net.Http.HttpClient client;
        string WebAPIUrl = string.Empty;
        public ProductService()
        {
            client = new System.Net.Http.HttpClient();
        }

        public async Task<List<AppMauiBlazorLoginJwt.Models.Product>> GetProducts(string token)
        {
            await Task.Delay(1000);          


            //WebAPIUrl = "http://189.254.239.133/LoginAppApi/api/login/autenticar";
            WebAPIUrl = "https://localhost:44321/api/product";

            //Con esta Api de ejemplo hice la prueba
            //WebAPIUrl = "https://ej2services.syncfusion.com/production/web-services/api/Orders"; 
            var uri = new Uri(WebAPIUrl);
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    List<AppMauiBlazorLoginJwt.Models.Product> _login = new List<AppMauiBlazorLoginJwt.Models.Product>();
                    var content = await response.Content.ReadAsStringAsync();
                    _login = JsonConvert.DeserializeObject<List<AppMauiBlazorLoginJwt.Models.Product>>(content);
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
