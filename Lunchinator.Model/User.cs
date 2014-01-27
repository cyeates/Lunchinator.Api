using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual Lunch Event { get; set; }
               

        public User()
        {
            Ratings = new List<Rating>();
            
           
        }

        public double GetRating(string businessId)
        {
            var rating = Ratings.FirstOrDefault(r => r.BusinessId == businessId);
            return rating != null ? rating.UserRating : 0;
        }

        public bool ContainsRating(string businessId)
        {
            return Ratings.FirstOrDefault(r => r.BusinessId == businessId) != null;
        }
       
    }
}
