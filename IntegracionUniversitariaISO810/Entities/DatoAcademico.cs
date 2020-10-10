using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracionUniversitariaISO810.Entities
{
    [Table("DatosAcademicos")]
    public class DatoAcademico
    {
        [Column("id")]
        [Key]
        public int ID { get; set; }
        public string MATRICULA { get; set; }
        public string DOCUMENTO_ESTUDIANTE { get; set; }
        public int TIPO_DOCUMENTO { get; set; }
        public string CODIGO_MATERIA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public int CREDITOS { get; set; }
        public int CALIFICACION { get; set; }
        public DateTime FECHA { get; set; }
    }
}
