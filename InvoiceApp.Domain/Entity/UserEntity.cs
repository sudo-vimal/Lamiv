using InvoiceApp.Domain.Entity.EnumEntities;
using InvoiceApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Domain.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string FirstName {  get; set; }

        public string? LastName { get; set; }

        public string UserName {get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Email { get; set; }

        public EUser UserTypeFK { get; set; }

        public virtual UserTypeEnum UserType { get; set; }

    }
}
