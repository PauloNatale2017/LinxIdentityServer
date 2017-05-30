using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public class ClientsMapping : EntityTypeConfiguration<IdentityServer3.Core.Models.Client>
    {
        public ClientsMapping()
        {
            ToTable("Client");
            HasKey(d => d.ClientId);
            Property(d => d.AbsoluteRefreshTokenLifetime);
            Property(d => d.AccessTokenLifetime);
            Property(d => d.AccessTokenType);
            Property(d => d.AllowAccessToAllCustomGrantTypes);
            Property(d => d.AllowAccessToAllScopes);
            Property(d => d.AllowClientCredentialsOnly);
            //Property(d => d.AllowedCorsOrigins);
            //Property(d => d.AllowedCustomGrantTypes);
            //Property(d => d.AllowedScopes);
            Property(d => d.AllowRememberConsent);
            Property(d => d.AlwaysSendClientClaims);
            Property(d => d.AuthorizationCodeLifetime);
            //Property(d => d.Claims);
            Property(d => d.ClientId);
            Property(d => d.ClientName);
            //Property(d => d.ClientSecrets);
            Property(d => d.ClientUri);
            Property(d => d.Enabled);
            Property(d => d.Flow);
            //Property(d => d.IdentityProviderRestrictions);
            Property(d => d.IdentityTokenLifetime);
            Property(d => d.IncludeJwtId);
            Property(d => d.LogoUri);
            //Property(d => d.PostLogoutRedirectUris);
            Property(d => d.PrefixClientClaims);
            //Property(d => d.RedirectUris);
            Property(d => d.RefreshTokenExpiration);
            Property(d => d.RefreshTokenUsage);
            Property(d => d.RequireConsent);
            Property(d => d.SlidingRefreshTokenLifetime);
            Property(d => d.UpdateAccessTokenClaimsOnRefresh);
        }
    }
}