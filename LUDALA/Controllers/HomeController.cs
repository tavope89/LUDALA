using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using LUDALA.Models;

namespace LUDALA.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rssUrl"></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(new FuncionalidadFeed().ReadFeed(new UrlsRssFeed().Noticias, 10));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rssUrl"></param>
        /// <returns></returns>
        public ActionResult Entretenimiento()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rssUrl"></param>
        /// <returns></returns>
        public ActionResult Deportes()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rssUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EntretenimientoRss()
        {
            var model = new FuncionalidadFeed().ReadFeed(new UrlsRssFeed().Entretenimiento, 10);
            var datosJson = new
            {
                Titulo=model.TituloFeed,
                Articulos=from art in model.Articulos
                          select new
                          {
                             art.Titulo,
                             art.Contenido,
                             art.Autor,
                            FechaPublicacion=art.FechaPublicacion.ToLongDateString(),
                             art.Link
                          }
            };

            return Json(datosJson);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rssUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeportesRss()
        {
             var model = new FuncionalidadFeed().ReadFeed(new UrlsRssFeed().Deportes, 10);
            var datosJson = new
            {
                Titulo = model.TituloFeed,
                Articulos = from art in model.Articulos
                            select new
                            {
                                art.Titulo,
                                art.Contenido,
                                art.Autor,
                                FechaPublicacion = art.FechaPublicacion.ToLongDateString(),
                                art.Link
                            }
            };
            return new JsonResult { Data = datosJson };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
