using EF_Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core.Interfaces
{
    interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorProduto(Guid Id);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Excluir(Guid Id );
        


    }
}
