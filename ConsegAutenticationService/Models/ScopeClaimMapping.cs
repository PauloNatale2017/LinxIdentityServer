using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public class ScopeClaimMapping : EntityTypeConfiguration<Models.ScopeClaim>
    {
        public ScopeClaimMapping()
        {
            ToTable("ScopeClaim");
            HasKey(d => d.Id);
            Property(d => d.AlwaysIncludeInIdToken);
            Property(d => d.Description);
            Property(d => d.Name);
        }
    }
}