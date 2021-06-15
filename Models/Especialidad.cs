using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int  IdEspecialidad{ get; set; }
        [Required (ErrorMessage ="Debe ingresar una descripción")]
        [Display(Name ="Descripción", Prompt ="Ingrese una descripción")]
        public string Descripcion {get; set;}
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }

    }
}