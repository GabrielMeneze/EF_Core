using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core.Domains
{
    public class PedidoItem
    {
        [Key]
        public Guid Id { get; set; }
        

        [ForeignKey("IdPedido")]
        public Guid IdPedido { get; set; }
        public Pedido Pedido { get; set; }

        [ForeignKey("IdProduto")]
        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; }


        public PedidoItem()
        {
            Id = Guid.NewGuid();
        }
    }
}
