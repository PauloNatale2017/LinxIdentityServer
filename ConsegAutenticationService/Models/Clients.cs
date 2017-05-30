using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public  class Clients : IdentityServer3.Core.Models.Client
    {
            [Key]
            public  int Id { get; set; }
            public string ClientName { get; set; }
            public string ClientId { get; set; }
         
            public string RedirectUris { get; set; }
            public string PostLogoutRedirectUris { get; set; }
            public List<string> AllowedScopes { get; set; }

            public string AbsoluteRefreshTokenLifetime{get;set;} 
            public string AccessTokenLifetime{get;set;}
            public string AccessTokenType{get;set;}
            public string AllowAccessToAllCustomGrantTypes{get;set;}
            public string AllowAccessToAllScopes{get;set;}
            public string AllowClientCredentialsOnly{get;set;}
            public string AllowedCorsOrigins{get;set;}
            public string AllowedCustomGrantTypes{get;set;}
            //public string AllowedScopes{get;set;}
            public string AllowRememberConsent{get;set;}
            public string AlwaysSendClientClaims{get;set;}
            public string AuthorizationCodeLifetime{get;set;}
            public string Claims{get;set;}
            //public string ClientId{get;set;}
            //public string ClientName{get;set;}
            public string ClientSecrets{get;set;}
            public string ClientUri{get;set;}
            public string Enabled{get;set;}
         
            public string IdentityProviderRestrictions{get;set;}
            public string IdentityTokenLifetime{get;set;}
            public string IncludeJwtId{get;set;}
            public string LogoUri{get;set;}
            //public string PostLogoutRedirectUris{get;set;}
            public string PrefixClientClaims{get;set;}
            //public string RedirectUris{get;set;}
            public string RefreshTokenExpiration{get;set;}
            public string RefreshTokenUsage{get;set;}
            public string RequireConsent{get;set;}
            public string SlidingRefreshTokenLifetime{get;set;}
            public string UpdateAccessTokenClaimsOnRefresh{get;set;}
            public int Flow { get; set; }
    }
}