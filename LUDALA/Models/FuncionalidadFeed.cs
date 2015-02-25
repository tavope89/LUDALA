using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Argotic.Common;
using Argotic.Syndication;

namespace LUDALA.Models
{
    public class FuncionalidadFeed 
    {
        /// <summary>
        /// 
        /// </summary>
        public FuncionalidadFeed()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feedUrl"></param>
        /// <param name="numberOfItems"></param>
        /// <returns></returns>
        public ContenidoRssFeed ReadFeed(string feedUrl, int numberOfItems)
        {
            var settings = new SyndicationResourceLoadSettings
            {
                RetrievalLimit = numberOfItems
            };
            var feed = GenericSyndicationFeed.Create(new Uri(feedUrl), settings);

            if (feed.Resource is RssFeed)
            {
                return ReadRssFeed((RssFeed) feed.Resource);
            }

            if (feed.Resource is AtomFeed)
            {
                return ReadAtomFeed((AtomFeed) feed.Resource);
            }

            throw new InvalidOperationException("Error Feed no soportado");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feed"></param>
        /// <returns></returns>
        private ContenidoRssFeed ReadRssFeed(RssFeed feed)
        {
            var rssContentModel = new ContenidoRssFeed
            {
                TituloFeed = feed.Channel.Title,
                Articulos = feed.Channel.Items.Select(item => new RssArticulo
                {
                    Titulo = item.Title,
                    Contenido = item.Description,
                    FechaPublicacion = item.PublicationDate,
                    Link = item.Link,
                    Autor = item.Author
                })
            };

            return rssContentModel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feed"></param>
        /// <returns></returns>
        private ContenidoRssFeed ReadAtomFeed(AtomFeed feed)
        {
            var rssContentModel = new ContenidoRssFeed
            {
                TituloFeed = feed.Title.Content,
                Articulos = feed.Entries.Select(item => new RssArticulo
                {
                    Titulo = item.Title.Content,
                    Contenido = item.Content.Content,
                    FechaPublicacion = item.PublishedOn,
                    Link = item.Links.FirstOrDefault().Uri,
                    Autor = string.Join(", ", item.Authors.Select(a => a.Name))
                })
            };

            return rssContentModel;
        }
    }
}
