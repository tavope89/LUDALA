using System;

namespace LUDALA.Models
{
    public class RssArticulo
    {
        /// <summary>
        /// Propiedad que almacena el título del articulo Rss
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Propiedad que almacena el contenido del articulo Rss
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Propiedad que almacena el posible nombre del Autor
        /// </summary>
        public string Autor { get; set; }
        /// <summary>
        /// Direccion que almacena la url del articulo Rss
        /// </summary>
        public Uri Link { get; set; }
        /// <summary>
        /// Valor que almacena la posible fecha de publicacion del articulo Rss
        /// </summary>
        public DateTime FechaPublicacion { get; set; }

       

        

        
    }
}