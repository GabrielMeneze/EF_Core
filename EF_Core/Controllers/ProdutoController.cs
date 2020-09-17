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

        public List<Produto> Get()
        {
            return _IprodutoRepository.Listar();
        }

        [HttpGet("{Id}")]
        public Produto Get(Guid Id)
        {
            return _IprodutoRepository.BuscarPorProduto(Id);
        }

        [HttpPost]
        public void Post(Produto produto)
        {
             _IprodutoRepository.Adicionar(produto);
        }

        [HttpPut("{Id}")]
        public void Put(Guid Id, Produto produto)
        {
            produto.Id = Id;
             _IprodutoRepository.Editar(produto);
        }


        [HttpDelete("{Id}")]
        public void Delete(Guid Id)
        {
            _IprodutoRepository.Excluir(Id);
        }




    }
}
