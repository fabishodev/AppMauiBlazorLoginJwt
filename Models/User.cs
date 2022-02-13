using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMauiBlazorLoginJwt.Models
{
    public class User : UserMin
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class UserMin
    {
        public string Nick { get; set; }
        public string Password { get; set; }

    }
}
