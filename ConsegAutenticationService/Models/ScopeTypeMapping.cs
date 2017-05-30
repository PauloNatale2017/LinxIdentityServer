using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public class ScopeTypeMapping : EntityTypeConfiguration<Models.ScopeType>
    {
        public ScopeTypeMapping()
        {
            ToTable("ScopeType");
            HasKey(d => d.Id);
            Property(d => d.Type);
        }
    }
}