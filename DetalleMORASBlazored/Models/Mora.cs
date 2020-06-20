using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DetalleMORASBlazored.Models
{
    public class Mora
    {
        [Key]
        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo  no puede ser menor que cero o mayor a 1000000.")]
        public int MoraId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio.")]
        [Range(1, 100000000, ErrorMessage = "El rango es de 1 a 1000000.")]
        public decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public virtual List<MoraDetalle> MoraDetalles { get; set; }


        public Mora()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            MoraDetalles = new List<MoraDetalle>();
        }
    }
}
