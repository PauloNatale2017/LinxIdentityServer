using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace LinxServerAuthentication.Models
{
    public class ScopeMapping : EntityTypeConfiguration<IdentityServer3.Core.Models.Scope>
    {
        public ScopeMapping()
        {
            ToTable("Scope");
           // HasKey(d => d.Id);
           // Property(d => d.Claim);
            Property(d => d.ClaimsRule);
            Property(d => d.Description);
            Property(d => d.DisplayName);
            Property(d => d.Emphasize);
            Property(d => d.Enabled);
            Property(d => d.IncludeAllClaimsForUser);
            Property(d => d.Name);
            Property(d => d.Required);
            Property(d => d.ShowInDiscoveryDocument);
            Property(d => d.Type);      
        }

      
    }
}