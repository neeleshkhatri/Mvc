// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.Framework.OptionsModel;

namespace FiltersWebSite
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicOptions>
    {
        public override Task<AuthenticationTicket> AuthenticateAsync()
        {
            var principal = new ClaimsPrincipal();
            principal.AddIdentity(new ClaimsIdentity(
                new Claim[] {
                    new Claim("Permission", "CanViewPage"),
                    new Claim("Manager", "yes"),
                    new Claim(ClaimTypes.Role, "Administrator"),
                    new Claim(ClaimTypes.NameIdentifier, "John")
                },
                Options.AuthenticationScheme));
            return Task.FromResult(new AuthenticationTicket(principal, 
                new AuthenticationProperties(), Options.AuthenticationScheme));
        }
    }
}