using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    public class ProjetoModeloContext : DbContext
    {
        //Aqui é onde entra a string de conexão ou nome por qual eu consigo encontrala
        public ProjetoModeloContext()
             : base("ProjetoModeloDDD")
        {

        }
           

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }



        //// sobrescrevendo o metodo para melhorar a performace
        //// usando as convenções

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

           modelBuilder.Properties()
               .Where(p => p.Name == p.ReflectedType.Name + "Id")
               .Configure(prop => prop.IsKey());

           modelBuilder.Properties<string>()
              .Configure(p => p.HasColumnType("varchar"));

           modelBuilder.Properties<string>()
              .Configure(p => p.HasMaxLength(100));

          modelBuilder.Configurations.Add(new ClienteConfiguration());
          modelBuilder.Configurations.Add(new ProdutoConfiguration());
       }

       public override int SaveChanges()
        {
     
           foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
          {

                if (entry.State == EntityState.Added)
                {

                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                   entry.Property("DataCadastro").IsModified = false;
               }

          }

            return base.SaveChanges();
        }

    }

}
