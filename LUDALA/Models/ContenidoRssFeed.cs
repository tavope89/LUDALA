using System;
using System.Collections.Generic;
using Argotic.Common;
using Argotic.Syndication;

namespace LUDALA.Models
{
    public class ContenidoRssFeed
    {
        /// <summary>
        /// Titulo que encabeza todos los articulos del RssFeed
        /// </summary>
        public string TituloFeed { get; set; }
        /// <summary>
        /// Articulos que contienen el Feed
        /// </summary>
        public IEnumerable<RssArticulo> Articulos { get; set; }

    }
}