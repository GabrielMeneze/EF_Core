using EF_Core.Context;
using EF_Core.Domains;
using EF_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {


        private readonly PedidoContext Ctx;
        public ProdutoRepository()
        {
            Ctx = new PedidoContext();
        }



        /// <summary>
        /// Adiciona um novo Produto
        /// </summary>
        /// <param name="produto">Objeto tipo produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Adiciona Objeto do tipo Produto ao DbSet do contexto
                Ctx.Produtos.Add(produto);

                //Salva alterações no contexto
                Ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// Buscar produtos pelo nome
        /// </summary>
        /// <param name="Nome">Nome do produto</param>
        /// <returns>retorna um ´produto</returns>
        public List<Produto> BuscarNome(string nome)
        {
            try
            {
                return Ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// Busca produtos por Id
        /// </summary>
        /// <param name="Id">id produto</param>
        /// <returns>Lista de produto</returns>
        public Produto BuscarPorProduto(Guid Id)
        {
            try
            {
                return Ctx.Produtos.Find(Id);
            } 
            catch (Exception ex)
            {

                throw new Exception(ex.Message); 
            }
        }



        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">produto a ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                Produto produtotemp = BuscarPorProduto(produto.Id);
                //Verefica se o produto existe
                if (produtotemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista altera propiedades 
                produtotemp.Nome = produto.Nome;
                produtotemp.Preco = produto.Preco;

                //Altera produtos no contexto
                Ctx.Produtos.Update(produtotemp);

                //Salva contexto
                Ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// Deleta o produto
        /// </summary>
        /// <param name="produto">Id do produto</param>
        public void Excluir(Guid Id)
        {
            try
            {
                Produto produtotemp = BuscarPorProduto(Id);
                //Verefica se o produto existe
                if (produtotemp == null)
                    throw new Exception("Produto não encontrado");

                //remove produto do dbset
                Ctx.Produtos.Remove(produtotemp);

                //Salva mudanças
                Ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Lista todos os produtos cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Produto> Listar()
        {
            try
            {
                return Ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}
