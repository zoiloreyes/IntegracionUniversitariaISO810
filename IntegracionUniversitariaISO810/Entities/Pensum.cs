using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracionUniversitariaISO810.Entities
{
    [Table("Pensums")]
    public class Pensum
    {
        [Column("Id")]
        [Key]
        public int ID { get; set; }
        public string CODIGO_MATERIA { get; set; }
        public string DESCRIPCION_MATERIA { get; set; }
        public string CODIGO_OFICIAL { get; set; }
        public byte CREDITOS { get; set; }
        public int CUATRIMESTRE { get; set; }
    }
}
