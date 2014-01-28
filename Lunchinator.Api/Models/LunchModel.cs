using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lunchinator.Api.Models
{
  public class LunchModel
  {
    public string LunchId { get; set; }
    public string Description { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Location { get; set; }

    
  }
}