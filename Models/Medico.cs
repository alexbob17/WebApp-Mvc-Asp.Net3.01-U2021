using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico{get; set;}
        [Required (ErrorMessage ="Debe ingresar un nombre")]
     
        public string Nombre {get; set;}
        [Required (ErrorMessage ="Debe ingresar una apellido")]

        public string Apellido {get; set;}
        [Required (ErrorMessage ="Debe ingresar una dirección")]
        [Display(Name ="Dirección")]

        public string Direccion {get; set;}
        [Required (ErrorMessage ="Debe ingresar un télefono")]
        [Display(Name ="Télefono")]

        public string Telefono {get; set;}
        [Required (ErrorMessage ="Debe ingresar una email")]
        [EmailAddress(ErrorMessage = "No es una direccion de email valida")]

        public string Email{get; set;}  
        [Display(Name ="Horario desde")] 
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString ="{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde {get; set;}
        [Display(Name ="Horario hasta")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString ="{0:hh:mm tt}", ApplyFormatInEditMode = true)]

        public DateTime HorarioAtencionHasta {get; set;}

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        
        public List<Turno> Turno {get; set;}
    }
}