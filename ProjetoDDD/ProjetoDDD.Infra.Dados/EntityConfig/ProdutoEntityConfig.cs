using ProjetoDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoDDD.Infra.Dados.EntityConfig
{
    public class ProdutoEntityConfig: EntityTypeConfiguration<Produto>, IMappingEntity
    {
        public ProdutoEntityConfig()
        {
            ToTable("Produtos");

            HasKey(p => p.ProdutoId);

            Property(p => p.Nome).IsRequired().HasMaxLength(150);
            Property(p => p.Valor).IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId);
        }
    }
}
