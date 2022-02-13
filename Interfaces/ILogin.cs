using AppMauiBlazorLoginJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMauiBlazorLoginJwt.Interfaces
{
    interface ILogin
    {
        Task<Login> Authenticate(UserMin userMin);
    }
}
