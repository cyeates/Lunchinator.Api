using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Entities
{
  public class User
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
  
    public Guid UserId { get; set; }
    public string EmailAddress { get; set; }
    public string FullName { get; set; }
    public virtual List<Rating> Ratings { get; set; }

    public Guid LunchId { get; set; }
    [ForeignKey("LunchId")]
    public virtual Lunch Lunch { get; set; }


    public User()
    {
      UserId = Guid.NewGuid();
      Ratings = new List<Rating>();


    }

    public double GetRating(string businessId)
    {
      var rating = Ratings.FirstOrDefault(r => r.RestaurantId == businessId);
      return rating != null ? rating.UserRating : 0;
    }

    public bool ContainsRating(string businessId)
    {
      return Ratings.FirstOrDefault(r => r.RestaurantId == businessId) != null;
    }

  }
}
