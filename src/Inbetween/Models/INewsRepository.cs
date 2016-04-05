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
                    Topic = o.Topic,
                    Text = o.Text,
                    Picture = o.Picture,
                    Date = o.Date
                })
                .ToArray();
        }
    }
}
