using System;
using System.Collections.Generic;
using System.Linq;
using Lunchinator.Data.Entities;
using Lunchinator.Data.Contracts;
namespace Lunchinator.Domain.Services
{
    public class UserService
    {
        
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
          this._uow = uow;
          
        }

        public User GetUser(int id)
        {
          return _uow.Users.GetById(id);
        }

        public void SaveRating(Rating rating, int userId)
        {
           var user = _uow.Users.GetById(userId);
           var existingRating = user.Ratings.FirstOrDefault(r => r.BusinessId == rating.BusinessId);
           if (existingRating != null)
           {
             existingRating.UserRating = rating.UserRating;
           }
           else
           {
             user.Ratings.Add(rating);
           }
           
           _uow.Commit();
        }

        public IEnumerable<Business> GetBusinessesToRateForEvent(Guid id)
        {
          var lunch = _uow.Lunches.GetAll().FirstOrDefault(l => l.LunchId == id);
            return lunch.Businesses.Take(5);
                       
        }

        
    }
}
