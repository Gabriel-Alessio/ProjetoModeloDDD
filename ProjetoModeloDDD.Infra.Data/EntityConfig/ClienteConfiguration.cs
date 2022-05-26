using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
  public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
  {
    public ClienteConfiguration()
    {
      HasKey(x => x.ClienteId);

      Property(x => x.Nome).IsRequired().HasMaxLength(150);
      Property(x => x.Sobrenome).IsRequired().HasMaxLength(150);
      Property(x => x.Email).IsRequired();
    }
  }
}
