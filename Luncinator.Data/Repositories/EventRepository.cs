using Lunchinator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Repositories
{
    public interface IEventRepository
    {
        Event GetById(Guid id);
        void Add(Event lunch);
        void Save();
    }
    public class EventRepository: IEventRepository
    {
        private LunchinatorContext _context;

        public EventRepository(LunchinatorContext context)
        {
            _context = context;
        }

        public Event GetById(Guid id)
        {
            return _context.Lunches.Include("Users").Include("Businesses").FirstOrDefault(e => e.EventId == id);
        }

        public void Add(Event lunch)
        {
            _context.Lunches.Add(lunch);
        }
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
            
        }
    }
}
