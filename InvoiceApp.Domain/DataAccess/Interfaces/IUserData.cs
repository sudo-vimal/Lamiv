using InvoiceApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Domain.DataAccess.Interfaces
{
    public interface IUserData
    {
        public UserEntity GetUserData();
    }
}
