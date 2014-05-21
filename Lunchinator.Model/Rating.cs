using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Entities
{
  public class Rating
  {
    [Key]
    public int RatingId { get; set; }
   
    public Guid UserId { get; set; }

    public string RestaurantId { get; set; }
    public double UserRating { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

  }
}
