namespace LinxServerAuthentication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LinxServerAuthentication.Context.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LinxServerAuthentication.Context.dbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        ///<summary>
        ///Configuração para Migrations na criação da estrutura EntityServer3.EntityFramework
        ///
        /// Enabling migrations
        /// Enable-Migrations -MigrationsDirectory Migrations\ClientConfiguration -ContextTypeName ClientConfigurationDbContext -ContextAssemblyName IdentityServer3.EntityFramework -ConnectionStringName IdSvr3Config
        /// Enable-Migrations -MigrationsDirectory Migrations\ScopeConfiguration -ContextTypeName ScopeConfigurationDbContext -ContextAssemblyName IdentityServer3.EntityFramework -ConnectionStringName IdSvr3Config
        /// Enable-Migrations -MigrationsDirectory Migrations\OperationalConfiguration -ContextTypeName OperationalDbContext -ContextAssemblyName IdentityServer3.EntityFramework -ConnectionStringName IdSvr3Config
        /// Adicionando a migração confg e sua inicialização 
        /// Add-Migration -Name InitialCreate -ConfigurationTypeName $ProjectRootNamespace$.Migrations.ScopeConfiguration.Configuration -ConnectionStringName IdSvr3Config
        /// Add-Migration -Name InitialCreate -ConfigurationTypeName $ProjectRootNamespace$.Migrations.ClientConfiguration.Configuration -ConnectionStringName IdSvr3Config
        /// Add-Migration -Name InitialCreate -ConfigurationTypeName $ProjectRootNamespace$.Migrations.OperationalConfiguration.Configuration -ConnectionStringName IdSvr3Config
        /// Criando a base baseada na estrutura EntityServer3.EntityFramework e seu relaciaonamento
        /// Update-Database -ConfigurationTypeName $ProjectRootNamespace$.Migrations.ClientConfiguration.Configuration -ConnectionStringName IdSvr3Config
        /// Update-Database -ConfigurationTypeName $ProjectRootNamespace$.Migrations.ScopeConfiguration.Configuration -ConnectionStringName IdSvr3Config
        /// Update-Database -ConfigurationTypeName $ProjectRootNamespace$.Migrations.OperationalConfiguration.Configuration -ConnectionStringName IdSvr3Config
        ///</summary>

    }
}
