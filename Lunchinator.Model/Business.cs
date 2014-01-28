using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Entities
{
  public class Business
  {
    [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Id { get; set; }

    [Key, Column(Order = 1)]
    public Guid LunchId { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string ImageUrl { get; set; }
    public double Rating { get; set; }
    public string Url { get; set; }

    [ForeignKey("LunchId")]
    public Lunch Lunch { get; set; }

    public Business()
    {
      
    }

  }


}
