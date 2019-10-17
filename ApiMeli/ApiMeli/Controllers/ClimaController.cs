//using Newtonsoft.Json;
using ApiMeli.Class;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiMeli.Controllers
{
    public class ClimaController : Controller
    {
        // GET: Clima
        [HttpGet]
        public ActionResult Clima(int dia)
        {           
            String obtenerdia = "";
            ClassSql ex = new ClassSql();
            obtenerdia = ex.diaparticular(dia);
            ViewBag.Tipo = obtenerdia;
            return View();
        }


        // GET: Periodos Sequía
        [HttpGet]
        public ActionResult Sequia()
        {
            String obtenerdia = "";
            ClassSql ex = new ClassSql();
            obtenerdia = ex.diaSequia();
            ViewBag.Sequia = obtenerdia;
            return View();
        }


        // GET: Periodos Lluvia
        [HttpGet]
        public ActionResult Lluvia()
        {
            String obtenerdia = "";
            String dias = "";
            ClassSql ex = new ClassSql();
            obtenerdia = ex.diaLluvia();
            ViewBag.Lluvia = obtenerdia;
            dias = ex.PicosLluvia();
            ViewBag.Dias = dias;
            return View();
        }

    }
}