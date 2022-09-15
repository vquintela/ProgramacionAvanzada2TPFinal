using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace schollApp.Models
{
    [Table("materia", Schema = "schollApp")]
    public class Materia
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_materia { get; set; }
        public String nombre_materia { get; set; }
        public String dia { get; set; }
        public String horario { get; set; }
        public String estado { get; set; }
       

    }
}
