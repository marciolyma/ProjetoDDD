using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.Dominio.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public string Observacoes { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }

        public string FullNome
        {
            get
            {
                return Nome + " " + SobreNome;
            }
        }

        //Serviço
        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }
    }
}
