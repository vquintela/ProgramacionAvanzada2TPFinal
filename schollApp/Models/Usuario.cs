using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schollApp.Models
{
    [Table("usuario", Schema = "schollApp")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string cuit_cuil { get; set; }
        public string rol { get; set; }
        public DateTime fecha_nac { get; set; }
        public string edad { get; set; }
        public string estado { get; set; }
    }
}
