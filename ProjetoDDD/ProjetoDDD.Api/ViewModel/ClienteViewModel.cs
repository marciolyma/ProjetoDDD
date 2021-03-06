﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.Api.ViewModel
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nome tem que ser cadastrado")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome tem que ser cadastrado")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo {0} caracteres")]
        public string SobreNome { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        [DisplayName("Observações")]
        public string Observacoes { get; set; }
        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}