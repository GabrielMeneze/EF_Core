using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core.Domains
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime OverDate { get; set; }

        public Pedido()
        {
            Id = Guid.NewGuid();
        }
    }
}
