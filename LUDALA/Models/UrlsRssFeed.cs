using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace LUDALA.Models
{
    public class UrlsRssFeed
    {
        /// <summary>
        /// Constructor de la clase el cual inicializa todas las Url por Omisión
        /// </summary>
        public UrlsRssFeed()
        {
            Noticias = "http://news.yahoo.com/rss/tech";
            Entretenimiento = "http://news.yahoo.com/rss/entertainment";
            Deportes = "http://news.yahoo.com/rss/sports";
        }

        /// <summary>
        /// Atributo que almacena la URL del RssFeed de Noticias
        /// </summary>
        public string Noticias
        {
            get;
            set;
        }
        /// <summary>
        /// Atributo que almacena la URL del RssFeed de Entretenimiento
        /// </summary>
        public string Entretenimiento
        {
            get;
            set;
        }
        /// <summary>
        /// Atributo que almacena la URL del RssFeed de Tecnología
        /// </summary>
        public string Deportes
        {
            get;
            set;
        }
    }

}