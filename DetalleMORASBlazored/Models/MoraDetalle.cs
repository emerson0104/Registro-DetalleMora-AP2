using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DetalleMORASBlazored.Models
{
    public class MoraDetalle
    {

        [Key]
        public int MoraDetalleId { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public decimal Valor { get; set; }

        public MoraDetalle()
        {
            MoraDetalleId = 0;
            MoraId = 0;
            PrestamoId = 0;
            Valor = 0;
        }
    }
}
