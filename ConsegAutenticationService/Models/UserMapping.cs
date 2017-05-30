using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Models
{
    public class UserMapping : EntityTypeConfiguration<IdentityServer3.Core.Services.InMemory.InMemoryUser>
    {
        public UserMapping()
        {
            ToTable("User");
            HasKey(d => d.ProviderId);
            Property(d => d.Username);
            Property(d => d.Password);
            Property(d => d.Subject);
           // Property(d => d.Claims);
          
        }
    }
}