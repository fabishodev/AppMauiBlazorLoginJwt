using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMauiBlazorLoginJwt.Interfaces
{
    interface IProduct
    {
        Task<List<AppMauiBlazorLoginJwt.Models.Product>> GetProducts(string token);
    }
}
