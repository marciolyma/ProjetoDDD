using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.Apresentacao.MVC.Models
{
    public class ClaimViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nome da Claim")]
        public string Type { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Valor da Claim")]
        public string Value { get; set; }
    }
}