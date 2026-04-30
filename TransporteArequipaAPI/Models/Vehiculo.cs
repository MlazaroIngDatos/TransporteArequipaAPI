using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransporteArequipaAPI.Models
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La placa es obligatoria")]
        [StringLength(10)]
        public string Placa { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroUnidad { get; set; }

        [StringLength(100)]
        public string TipoServicio { get; set; }

        public int Capacidad { get; set; }

        [StringLength(150)]
        public string RutaActual { get; set; }

        public bool EnMantenimiento { get; set; }

        public int AnioFabricacion { get; set; }

        // PROPIEDAD PARA ELIMINACIÓN LÓGICA
        // Por defecto es true para que los nuevos registros estén activos
        public bool EstaActivo { get; set; } = true;
    }
}


