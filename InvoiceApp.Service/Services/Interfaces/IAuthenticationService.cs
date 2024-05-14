using InvoiceApp.Service.Models;

namespace InvoiceApp.Service.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public ServiceResponse Login(UserLoginCredentials credentials);
    }
}