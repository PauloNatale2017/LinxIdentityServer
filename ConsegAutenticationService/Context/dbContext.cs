using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Context
{
    public class dbContext : DbContext
    {
        public dbContext() : base("DbConseg") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Repository.entidades.User> _User { get; set; }
        public DbSet<Repository.entidades.Client> _Client { get; set; }
        public DbSet<Repository.entidades.ClientClaim> _ClientClaim { get; set; }
        public DbSet<Repository.entidades.ClientCorsOrigin> _ClientCorsOrigin { get; set; }
        public DbSet<Repository.entidades.ClientCustomGrantType> _ClientCustomGrantType { get; set; }
        public DbSet<Repository.entidades.ClientIdPRestriction> _ClientIdPRestriction { get; set; }
        public DbSet<Repository.entidades.ClientPostLogoutRedirectUri> _ClientPostLogoutRedirectUri { get; set; }
        public DbSet<Repository.entidades.ClientRedirectUri> _ClientRedirectUri { get; set; }
        public DbSet<Repository.entidades.ClientScope> _ClientScope { get; set; }
        public DbSet<Repository.entidades.ClientSecret> _ClientSecret { get; set; }
        public DbSet<Repository.entidades.Consent> _Consent { get; set; }
        public DbSet<Repository.entidades.Scope> _Scope { get; set; }
        public DbSet<Repository.entidades.ScopeClaim> _ScopeClaim { get; set; }
        public DbSet<Repository.entidades.ScopeSecret> _ScopeSecret { get; set; }
        public DbSet<Repository.entidades.Token> _Token { get; set; }
        public DbSet<Repository.entidades.UserClaimsConseg> _UserClaimsConseg { get; set; }
        public DbSet<Repository.entidades.RolesAccess> _RolesAccess { get; set; }

    }
}