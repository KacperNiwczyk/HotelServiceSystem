using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace HotelServiceSystem
{
    public class HotelServiceAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
           var identity = new ClaimsIdentity(new []
           {
               new Claim(ClaimTypes.Name, "kacper.niwczyk") 
           }, "apiauth_type");
           
           var user = new ClaimsPrincipal(identity);

           return Task.FromResult(new AuthenticationState(user));
        }
    }
}