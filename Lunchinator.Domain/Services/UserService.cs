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

        public User GetUser(Guid id)
        {
          return _uow.Users.GetById(id);
        }

        public void SaveRatings(IEnumerable<Rating> ratings, Guid userId)
        {
           var user = _uow.Users.GetById(userId);
          foreach (var rating in ratings)
          {
            var existingRating = user.Ratings.FirstOrDefault(r => r.RestaurantId == rating.RestaurantId);
            if (existingRating != null)
            {
              existingRating.UserRating = rating.UserRating;
            }
            else
            {
              user.Ratings.Add(rating);
            }
          }
          _uow.Commit();
        }

        public IEnumerable<Business> GetBusinessesToRateForEvent(Guid id)
        {
          var lunch = _uow.Lunches.GetById(id);
          return lunch.Businesses.Take(5);
                     
        }

        
    }
}
