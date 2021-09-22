using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSegundoParcial.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Producto { get; set; }
        [Required(ErrorMessage = "La descripción del producto es obligatoria")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio costo del producto es obligatorio")]
        public decimal Precio_costo { get; set; }
        [Required(ErrorMessage = "El precio venta del producto es obligatorio")]
        public decimal Precio_venta { get; set; }
        [Required(ErrorMessage = "La existencia del producto es obligatoria")]
        public int Existencia { get; set; }

        [Required(ErrorMessage = "La marca del producto es obligatoria")]
        [Display(Name = "Marca")]
        public int Marca_Id { get; set; }
        [ForeignKey("Marca_Id")]
        public virtual Marcas Marcas { get; set; }

        [Required(ErrorMessage = "El estado de la marca es obligatorio")]
        [Display(Name = "Estado")]
        public int Estado_Id { get; set; }
        [ForeignKey("Estado_Id")]
        public virtual Estados Estados { get; set; }
    }
}
