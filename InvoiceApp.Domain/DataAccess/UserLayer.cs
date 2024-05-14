using InvoiceApp.Domain.DataAccess.Interfaces;
using InvoiceApp.Domain.Entity;
using InvoiceApp.Domain.Mappers;
using InvoiceApp.Domain.Models;


namespace InvoiceApp.Domain.DataAccess
{
    public class UserLayer : IUserLayer
    {
        private readonly UserContext _userContext;
        public UserLayer(UserContext userContext)
        {
            _userContext = userContext;
        }

        public UserDetails? GetUserData(UserData userData)
        {
            UserEntity? userEntity = null;
            UserDetails? userDetails = null;
            if (userData != null)
            {
                userEntity = _userContext.Users.FirstOrDefault(x => x.UserName == userData.UserName);
            }
            if(userEntity != null)
            {
                userDetails=UserMapper.MapToUserDetails(userEntity);
            }
            return userDetails;
        }

    }
}
