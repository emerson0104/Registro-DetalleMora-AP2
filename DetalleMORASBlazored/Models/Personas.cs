using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DetalleMORASBlazored.Models
{
    public class Personas
    {
        [Key]
        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo no puede ser menor que cero o mayor a 1000000.")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "El campo  no puede estar vacío.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener por lo menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre es muy largo.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo telefono no puede estar vacío.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor ingrese un No. de teléfono válido.")]
        [MaxLength(10, ErrorMessage = "El campo no tiene más de diez dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo  no puede estar vacío.")]
        [Phone(ErrorMessage = "Debe ser numerica la cedula")]
        [MinLength(9, ErrorMessage = "El campo cedula debe contener 11 caracteres.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo  no puede estar vacía.")]
        [MinLength(10, ErrorMessage = "La dirección es muy corta.")]
        [MaxLength(40, ErrorMessage = "La dirección debe contener menos de 40 caracteres.")]
        public string Direccion { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }

        public decimal Balance { get; set; }

        public Personas()
        {
            PersonaId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Fecha = DateTime.Now;
            Balance = 0;
        }
    }
}
