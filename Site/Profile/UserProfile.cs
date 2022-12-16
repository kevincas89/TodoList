using Entity;
using Site.Models;
using System.Text.RegularExpressions;

namespace Site.Profile
{
    public class UserProfile : Profile 
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
