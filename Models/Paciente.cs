using System.ComponentModel.DataAnnotations;

namespace turnos.Models
{
    public class Paciente
    {
        [Key]
        public int  IdPaciente{ get; set; }
        [Required (ErrorMessage ="Debe ingresar un Nombre")]
        [Display(Name ="Paciente")]

        public string Nombre {get; set;}
        [Required (ErrorMessage ="Debe ingresar un Apellido")]
        [Display(Name ="Apellido")]
        public string Apellido {get; set;}
        [Required (ErrorMessage ="Debe ingresar una Direccion")]
        [Display(Name ="Direccion")]
        public string Direccion {get; set;}
        [Required (ErrorMessage ="Debe ingresar un Telefono")]
        [Display(Name ="Telefono")]
        public string Telefono {get; set;}
        [Required (ErrorMessage ="Debe ingresar una email")]
        [EmailAddress(ErrorMessage = "No es una direccion de email valida")]
        public string Email {get; set;}

    }
}