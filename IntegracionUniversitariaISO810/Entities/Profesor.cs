using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracionUniversitariaISO810.Entities
{
    [Table("Profesores")]
    public class Profesor
    {
        [Column("Id")]
        [Key]
        public int ID { get; set; }
        public string DOCUMENTO_PROFESOR { get; set; }
        public int TIPO_DOCUMENTO { get; set; }
        public int CREDITOS_TOTALES { get; set; }
    }
}
