using Inbetween.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.Models
{
    public interface IIndexRepository
    {
        IndexVM GetIndexVM();
        IndexVM GetIndexVMAdmin();
    }
    public class IndexRepository : IIndexRepository
    {
        INewsRepository news;
        IAlbumsRepository albums;

        public IndexRepository(INewsRepository news, IAlbumsRepository albums)
        {
            this.news = news;
            this.albums = albums;
        }

        public IndexVM GetIndexVM() // DENNA ÄR AWESOME TILL INDEX!
        {
            var model = new IndexVM
            {
                ListNews = news.GetTop3(),
                ListAlbums = albums.GetAllAlbums(),
                MailSenderVMThing = new MailSenderVM()
            };
            return model;
        }

        public IndexVM GetIndexVMAdmin() // DENNA ÄR AWESOME TILL INDEX!
        {
            var model = new IndexVM
            {
                ListNews = news.GetAll(),
                ListAlbums = albums.GetAllAlbums(),
                MailSenderVMThing = new MailSenderVM()
            };
            return model;
        }
    }
}
