using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSegundoParcial.Models
{
    public class Marcas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la marca es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El estado de la marca es obligatorio")]
        [Display(Name = "Estado")]
        public int Estado_Id { get; set; }
        [ForeignKey("Estado_Id")]
        public virtual Estados Estados { get; set; }
    }
}
