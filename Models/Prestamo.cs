using System.ComponentModel.DataAnnotations;

namespace JendriHidalgo_Ap1_P1.Models
{
    public class Prestamo
    {

        [Key]

        public int DeudorId { get; set; }

        [Required(ErrorMessage = "El campo Deudor es obligatorio")]  

        public string Deudor { get; set; }

        [Required(ErrorMessage = "El campo Concepto es obligatorio")]
        public string Concepto { get; set; }

        public int Monto { get; set; }

    }
}
