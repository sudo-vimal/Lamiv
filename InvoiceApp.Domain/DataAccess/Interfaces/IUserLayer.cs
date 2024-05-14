using InvoiceApp.Domain.Entity;
using InvoiceApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Domain.DataAccess.Interfaces
{
    public interface IUserLayer
    {
        public UserDetails? GetUserData(UserData userData);
    }
}
