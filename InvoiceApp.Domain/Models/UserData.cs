using InvoiceApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Domain.Models
{
    public class UserData
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }

    public class UserDetails : UserData
    {
        public string Password { get; set; }

        public EUser UserType { get; set; }
    }
}
