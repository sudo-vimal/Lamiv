using InvoiceApp.Domain.Entity;
using InvoiceApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Domain.Mappers
{
    public static class UserMapper
    {
        public static UserDetails MapToUserDetails(this UserEntity entity)
        {
            return new UserDetails()
            {
                UserName=entity.UserName,
                Email=entity.Email,
                Password = entity.Password,
                UserType=entity.UserTypeFK
            };
        }
    }
}
