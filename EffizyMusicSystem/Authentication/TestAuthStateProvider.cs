using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.AuthProviders
{
    public class TestAuthStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(1500);

            var anonymous = new ClaimsIdentity();
            
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
    }
}
