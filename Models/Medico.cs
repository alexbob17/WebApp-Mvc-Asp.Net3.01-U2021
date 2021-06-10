using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico{get; set;}

        public string Nombre {get; set;}

        public string Apellido {get; set;}

        public string Direccion {get; set;}

        public string Telefono {get; set;}

        public string Email{get; set;}    

        public DateTime HorarioAtencionDesde {get; set;}

        public DateTime HorarioAtencionHasta {get; set;}

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        
    }
}