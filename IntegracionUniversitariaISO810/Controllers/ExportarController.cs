using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IntegracionUniversitariaISO810.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntegracionUniversitariaISO810.Controllers
{
    public class ExportarController : Controller
    {
        private readonly IntegracionDBContext _context;

        public ExportarController(IntegracionDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DatosAcademicos()
        {
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);

            _context.DatosAcademicos.ToList().ForEach(d =>
            {
                tw.WriteLine($"{d.ID}|{d.MATRICULA}|{d.DOCUMENTO_ESTUDIANTE}|{d.TIPO_DOCUMENTO}|{d.CODIGO_MATERIA}|{d.DESCRIPCION_MATERIA}|{d.CREDITOS}|{d.CALIFICACION}|{d.FECHA.ToString("yyyy-MM-dd")}");
            });
            tw.Flush();

            var length = memoryStream.Length;
            tw.Close();
            var toWrite = new byte[length];
            Array.Copy(memoryStream.GetBuffer(), 0, toWrite, 0, length);

            return File(toWrite, "text/plain", "DatosAcademicos.txt");
        }

        public IActionResult Profesores()
        {
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);

            _context.Profesores.ToList().ForEach(d =>
            {
                tw.WriteLine($"{d.ID}|{d.DOCUMENTO_PROFESOR}|{d.TIPO_DOCUMENTO}|{d.CREDITOS_TOTALES}");
            });
            tw.Flush();

            var length = memoryStream.Length;
            tw.Close();
            var toWrite = new byte[length];
            Array.Copy(memoryStream.GetBuffer(), 0, toWrite, 0, length);

            return File(toWrite, "text/plain", "Profesores.txt");
        }

        public IActionResult Estudiantes()
        {
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);

            _context.Estudiantes.ToList().ForEach(e =>
            {
                tw.WriteLine($"{e.ID}|{e.DOCUMENTO}|{e.TIPO_DOCUMENTO}|{e.CREDITOS_CURSADOS}|{e.TANDA}|{e.INDICE_ACUMULADO}");
            });
            tw.Flush();

            var length = memoryStream.Length;
            tw.Close();
            var toWrite = new byte[length];
            Array.Copy(memoryStream.GetBuffer(), 0, toWrite, 0, length);

            return File(toWrite, "text/plain", "Estudiantes.txt");
        }

        public IActionResult Pensums()
        {
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);

            _context.Pensums.ToList().ForEach(p =>
            {
                tw.WriteLine($"{p.ID}|{p.CODIGO_MATERIA}|{p.DESCRIPCION_MATERIA}|{p.CODIGO_OFICIAL}|{p.CREDITOS}|{p.CUATRIMESTRE}");
            });
            tw.Flush();

            var length = memoryStream.Length;
            tw.Close();
            var toWrite = new byte[length];
            Array.Copy(memoryStream.GetBuffer(), 0, toWrite, 0, length);

            return File(toWrite, "text/plain", "Pensums.txt");
        }
    }
}