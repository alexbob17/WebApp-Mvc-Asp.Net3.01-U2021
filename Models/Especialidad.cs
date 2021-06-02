using System.ComponentModel.DataAnnotations;

namespace turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int  IdEspecialidad{ get; set; }
        public string Descripcion {get; set;}

    }
}