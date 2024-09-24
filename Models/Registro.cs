using System.ComponentModel.DataAnnotations;

namespace JendriHidalgo_Ap1_P1.Models
{
    public class Registro
    {

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

    }
}
