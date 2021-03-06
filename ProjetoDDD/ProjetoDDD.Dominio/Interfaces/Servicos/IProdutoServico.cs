﻿using ProjetoDDD.Dominio.Entidades;
using System.Collections.Generic;

namespace ProjetoDDD.Dominio.Interfaces.Servicos
{
    public interface IProdutoServico: IServicoBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscaProdutoCliente(int id);
    }
}
