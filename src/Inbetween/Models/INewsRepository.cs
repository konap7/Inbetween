using Inbetween.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.Models
{
    public interface INewsRepository
    {
        ListNewsVM[] GetAll();
        ListNewsVM[] GetTop3();
        void AddNews(AddNewsVM newNews);
        void DeleteNewsPost(int id);
    }
    public class DBNewsRepository : INewsRepository
    {
        KickAssDataBaseContext context;
        public DBNewsRepository(KickAssDataBaseContext context)
        {
            this.context = context;
        }

        public ListNewsVM[] GetTop3()
        {
            return context.Inbetween_News
                .OrderByDescending(o => o.Date)
                .Select(o => new ListNewsVM
                {
                    Topic = o.Topic,
                    Text = o.Text,
                    Picture = o.Picture,
                    Date = o.Date
                })
                .Take(3)
                .ToArray();
        }

        public ListNewsVM[] GetAll()
        {
            return context.Inbetween_News
                .OrderByDescending(o => o.Date)
                .Select(o => new ListNewsVM
                {
                    Id = o.Id,
                    Topic = o.Topic,
                    Text = o.Text,
                    Picture = o.Picture,
                    Date = o.Date
                })
                .ToArray();
        }

        public void AddNews(AddNewsVM newNews)
        {
            context.Inbetween_News.Add(new News
            {
                Topic = newNews.Topic,
                Text = newNews.Text,
                Picture = newNews.Picture,
                Date = DateTime.Now
            });

            context.SaveChanges();
        }

        public void DeleteNewsPost(int id)
        {
            var newsPost = context.Inbetween_News.Single(n => n.Id == id);
            context.Inbetween_News.Remove(newsPost);

            context.SaveChanges();
        }
    }
}
