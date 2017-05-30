using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LinxServerAuthentication.Context
{
    public class dbConsegContext : DbContext
    {
        public dbConsegContext() : base("DbConsegII") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {         
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Repository.entidadesConsegs.MEMBRO> _MEMBRO { get; set; }
        public DbSet<Repository.entidadesConsegs.PESSOA> _PESSOA { get; set; }
        public DbSet<Repository.entidadesConsegs.ACESSOS_CONSEG> _ACESSOS_CONSEG { get; set; }

    }

}