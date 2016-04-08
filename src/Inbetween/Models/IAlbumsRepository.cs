using Inbetween.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.Models
{
    public interface IAlbumsRepository
    {
        ListAlbumsVM[] GetAllAlbums();
        void AddAlbum(AddAlbumVM newAlbum);
        void DeleteAlbum(int id);

        //IndexVM GetIndexVM();
    }
    public class DBAlbumsRepository : IAlbumsRepository
    {
        KickAssDataBaseContext context;
        public DBAlbumsRepository(KickAssDataBaseContext context)
        {
            this.context = context;
        }

        public ListAlbumsVM[] GetAllAlbums()
        {
            return context.Inbetween_Albums
                .OrderByDescending(o => o.Date)
                .Select(o => new ListAlbumsVM
                {
                    Id = o.Id,
                    Albumname = o.Albumname,
                    Date = o.Date,
                    Tracks = o.Tracks,
                    Picture = o.Picture
                })
                .ToArray();
        }

        public void AddAlbum(AddAlbumVM newAlbum)
        {
            context.Inbetween_Albums.Add(new Albums
            {
                Albumname = newAlbum.Albumname,
                Date = DateTime.Now,
                Tracks = newAlbum.Tracks,
                Picture = newAlbum.Picture
            });

            context.SaveChanges();
        }

        public void DeleteAlbum(int id)
        {
            var albumPost = context.Inbetween_Albums.Single(n => n.Id == id);
            context.Inbetween_Albums.Remove(albumPost);

            context.SaveChanges();
        }
    }
}
