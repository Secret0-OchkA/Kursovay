using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DockerTestBD.Api
{
    public class AuthOptions //я поменяю Ü
    {
        public const string ISSUER = "Secretus"; 
        public const string AUDIENCE = "mobileApp"; 
        const string KEY = "secretochka2442";   
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
