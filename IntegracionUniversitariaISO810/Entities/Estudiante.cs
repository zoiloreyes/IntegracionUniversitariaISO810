using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracionUniversitariaISO810.Entities
{
    [Table("Estudiantes")]
    public class Estudiante
    {
        [Column("id")]
        [Key]
        public int ID { get; set; }
        public string DOCUMENTO { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public int CREDITOS_CURSADOS { get; set; }
        public string TANDA { get; set; }
        public decimal INDICE_ACUMULADO { get; set; }

    }
}
