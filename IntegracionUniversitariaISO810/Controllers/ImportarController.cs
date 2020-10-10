using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionUniversitariaISO810.Context;
using IntegracionUniversitariaISO810.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionUniversitariaISO810.Controllers
{
    public class ImportarController : Controller
    {
        private readonly IntegracionDBContext _context;

        public ImportarController(IntegracionDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DatosAcademicos(IFormFile file)
        {
            try
            {
                List<DatoAcademico> datosAcad = new List<DatoAcademico>();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        DatoAcademico d = new DatoAcademico();
                        var line = reader.ReadLine();
                        var array = line.Split("|");
                        d.MATRICULA = array[1];
                        d.DOCUMENTO_ESTUDIANTE = array[2];
                        d.TIPO_DOCUMENTO = Convert.ToInt32(array[3]);
                        d.CODIGO_MATERIA = array[4];
                        d.DESCRIPCION_MATERIA = array[5];
                        d.CREDITOS = Convert.ToInt32(array[6]);
                        d.CALIFICACION = Convert.ToInt32(array[7]);
                        d.FECHA = Convert.ToDateTime(array[8]);

                        datosAcad.Add(d);
                    }
                }

                datosAcad.ForEach(d =>
                {
                    _context.DatosAcademicos.Add(d);
                });
                _context.SaveChanges();
                ViewBag.Msg = "Datos guardados exitosamente";
            }catch(Exception e)
            {
                ViewBag.Msg = "Error al procesar el archivo";
            }
            
            return View("Index");
        }

        public IActionResult Pensums(IFormFile file)
        {
            try
            {
                List<Pensum> pensums = new List<Pensum>();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        Pensum p = new Pensum();
                        var line = reader.ReadLine();
                        var array = line.Split("|");
                        p.CODIGO_MATERIA = array[1];
                        p.DESCRIPCION_MATERIA = array[2];
                        p.CODIGO_OFICIAL = array[3];
                        p.CREDITOS = Convert.ToByte(array[4]);
                        p.CUATRIMESTRE = Convert.ToInt32(array[5]);

                        pensums.Add(p);
                    }
                }

                pensums.ForEach(d =>
                {
                    _context.Pensums.Add(d);
                });
                _context.SaveChanges();
                ViewBag.Msg = "Datos guardados exitosamente";
            }
            catch (Exception e)
            {
                ViewBag.Msg = "Error al procesar el archivo";
            }

            return View("Index");
        }

        public IActionResult Estudiantes(IFormFile file)
        {
            try
            {
                List<Estudiante> estudiantes = new List<Estudiante>();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        Estudiante e = new Estudiante();
                        var line = reader.ReadLine();
                        var array = line.Split("|");
                        e.DOCUMENTO = array[1];
                        e.TIPO_DOCUMENTO = array[2];
                        e.CREDITOS_CURSADOS = Convert.ToInt32(array[3]);
                        e.TANDA = array[4];
                        e.INDICE_ACUMULADO = Convert.ToDecimal(array[5]);

                        estudiantes.Add(e);
                    }
                }

                estudiantes.ForEach(e =>
                {
                    _context.Estudiantes.Add(e);
                });
                _context.SaveChanges();
                ViewBag.Msg = "Datos guardados exitosamente";
            }
            catch (Exception e)
            {
                ViewBag.Msg = "Error al procesar el archivo";
            }

            return View("Index");
        }

        public IActionResult Profesores(IFormFile file)
        {
            try
            {
                List<Profesor> profesores = new List<Profesor>();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        Profesor p = new Profesor();
                        var line = reader.ReadLine();
                        var array = line.Split("|");
                        p.DOCUMENTO_PROFESOR = array[1];
                        p.TIPO_DOCUMENTO = Convert.ToInt32(array[2]);
                        p.CREDITOS_TOTALES = Convert.ToInt32(array[3]);

                        profesores.Add(p);
                    }
                }

                profesores.ForEach(d =>
                {
                    _context.Profesores.Add(d);
                });
                _context.SaveChanges();
                ViewBag.Msg = "Datos guardados exitosamente";
            }
            catch (Exception e)
            {
                ViewBag.Msg = "Error al procesar el archivo";
            }

            return View("Index");
        }
    }
}