using InvoiceApp.Domain;
using InvoiceApp.Domain.DataAccess.Interfaces;
using InvoiceApp.Domain.Entity;
using InvoiceApp.Domain.Helpers;
using InvoiceApp.Domain.Mappers;
using InvoiceApp.Domain.Models;
using InvoiceApp.Service.Models;
using InvoiceApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserLayer _userLayer;
        public AuthenticationService(IUserLayer userLayer)
        {
            _userLayer = userLayer;
        }

        public ServiceResponse Login(UserLoginCredentials credentials)
        {
            ServiceResponse response = new ServiceResponse()
            {
                Success = false
            };
            UserData userData = new UserData()
            {
                UserName = credentials.UserName
            };

            UserDetails? userDetails = _userLayer.GetUserData(userData);
            if (userDetails != null)
            {
                using (SHA256 mySHA256 = SHA256.Create())
                {
                    if (string.Compare(CommonHelper.GetHash(mySHA256, credentials.Password), userDetails.Password, StringComparison.Ordinal) == 0)
                    {
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Invalid Password/username";
                    }
                }
            }
            else
            {
                response.Message = "Couldn't find user with given credentials";
            }

            return response;
        }

    }
}
