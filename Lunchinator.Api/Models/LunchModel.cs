using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lunchinator.Data.Entities;

namespace Lunchinator.Api.Models
{
  public class LunchModel
  {
    public string LunchId { get; set; }
    public string Description { get; set; }
    public IEnumerable<UserModel> Users { get; set; }
    public IEnumerable<RestaurantModel> Restaurants { get; set; } 

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Location { get; set; }

    public LunchModel()
    {
      Users = new List<UserModel>();
      Restaurants = new List<RestaurantModel>();
    }
  }

  public class UserModel
  {
    public string EmailAddress { get; set; }
  }

  public class RestaurantModel
  {
    public string RestaurantId { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string ImageUrl { get; set; }
    public double Rating { get; set; }
    public string Url { get; set; }
  }
}