using ProjetoDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoDDD.Infra.Dados.EntityConfig
{
    public class ClienteEntityConfig: EntityTypeConfiguration<Cliente>, IMappingEntity
    {
        public ClienteEntityConfig()
        {
            ToTable("Clientes");

            HasKey(c => c.ClienteId);

            Property(c => c.Nome).IsRequired().HasMaxLength(150);
            Property(c => c.SobreNome).IsRequired().HasMaxLength(150);
            Property(c => c.Email).IsRequired().HasMaxLength(254);
            Property(c => c.Observacoes).HasMaxLength(600);
        }
    }
}
