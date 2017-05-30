using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public class AllowedScopesMapping : EntityTypeConfiguration<Models.AllowedScopes>
    {
        public AllowedScopesMapping()
        {
            ToTable("AllowedScopes");
            HasKey(d => d.Id);
            //Property(d => d.Claims);
            Property(d => d.ClaimsRule);
            Property(d => d.Description);
            Property(d => d.DisplayName);
            Property(d => d.Emphasize);
            Property(d => d.Enabled);
            Property(d => d.IncludeAllClaimsForUser);
            Property(d => d.Name);
            Property(d => d.Required);
            Property(d => d.ShowInDiscoveryDocument);
          
        }
    }
}