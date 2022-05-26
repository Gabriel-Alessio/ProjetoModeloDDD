using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
  public class ProjetoModeloContext : DbContext 
  {
    public ProjetoModeloContext()
      :base("Data Source=DESKTOP-JTDTTH4;Initial Catalog=ProjetoModeloDB;Integrated Security=True")
    {

    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
      modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

      modelBuilder.Properties()
        .Where(x => x.Name == x.ReflectedType.Name + "Id")
        .Configure(x => x.IsKey());

      modelBuilder.Properties<string>()
        .Configure(x => x.HasColumnType("varchar"));

      modelBuilder.Properties<string>()
        .Configure(x => x.HasMaxLength(100));

      modelBuilder.Configurations.Add(new ClienteConfiguration());
      modelBuilder.Configurations.Add(new ProdutoConfiguration());
    }

    public override int SaveChanges()
    {
      var entries = ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("DataCadastro") != null);
      foreach (var entry in entries)
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
