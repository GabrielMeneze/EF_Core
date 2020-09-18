using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core.Domains;
using EF_Core.Interfaces;
using EF_Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _IprodutoRepository;

        
        public ProdutoController()
        {
            _IprodutoRepository = new ProdutoRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var produtos = _IprodutoRepository.Listar();

                //Verifica se existe produto
                if (produtos.Count == 0)
                    return NoContent();

                //Caso exista
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                //Caso aconteça algum erro
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                //Buscar produto no repositorio
                var produto =  _IprodutoRepository.BuscarPorProduto(Id);

                //verifica se o produto existe
                if (produto == null)
                    return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {
                //ADICIONA UM PRODUTO
                _IprodutoRepository.Adicionar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id, Produto produto)
        {
            try
            {
                produto.Id = Id;
                _IprodutoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _IprodutoRepository.Excluir(Id);

                return Ok(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }




    }
}
