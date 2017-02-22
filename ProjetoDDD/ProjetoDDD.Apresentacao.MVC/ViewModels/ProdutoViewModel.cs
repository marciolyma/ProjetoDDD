using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.Apresentacao.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Nome tem que ser informado")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Valor tem que ser informado")]
        [DisplayFormat(DataFormatString ="{0:N}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; set; }

        [DisplayName("Disponível?")]
        public bool Disponivel { get; set; }
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}