using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Lunchinator.Api.Models;
using Lunchinator.Data.Entities;
using Lunchinator.Domain;
using Lunchinator.Domain.Services;

namespace Lunchinator.Api.Controllers
{
  [EnableCors("*", "*", "*")]
  public class LunchesController : ApiController
  {
    private readonly LunchService _lunchService;
    
    public LunchesController(LunchService lunchService)
    {
      _lunchService = lunchService;
    }

    [HttpGet]
    public LunchModel Get(string id)
    {
      var lunch =  _lunchService.GetLunch(new Guid(id));
      var users = new List<UserModel>();
      lunch.Users.ForEach(u => users.Add(new UserModel { EmailAddress = u.EmailAddress }));

      var businesses = new List<RestaurantModel>();
      lunch.Businesses.ForEach(b => businesses.Add(new RestaurantModel
      {
        RestaurantId = b.Id,
        Name = b.Name,
        Address1 = b.Address1,
        Address2 = b.Address2,
        ImageUrl = b.ImageUrl,
        Rating = b.Rating,
        Url = b.Url
      }));
     
      var model= new LunchModel
      {
        LunchId = lunch.LunchId.ToString(),
        Users = users,
        Restaurants = businesses
      };

      return model;
    }
    
      [HttpPost]
    public LunchModel Create(LunchModel model)
    {
      var lunch = new Lunch { Description = model.Description };
      var searchParameters = new SearchParameters
      {
        Latitude = model.Latitude,
        Longitude = model.Longitude,
        Location = model.Location
      };
      var createdLunch = _lunchService.CreateLunch(lunch, searchParameters);
      return new LunchModel {LunchId = createdLunch.LunchId.ToString()};
    }

    [HttpPost]
    public HttpResponseMessage Invite(InviteUserModel model)
    {
      try
      {
        var user = _lunchService.InviteUser(model.LunchId, model.EmailAddress);
        return Request.CreateResponse(HttpStatusCode.OK, user.UserId.ToString());
      }
      catch (Exception ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
      }
     
    }

    public Business GetRecommendation(Guid lunchId)
    {
      return _lunchService.GetRecommendation(lunchId);
    }
  }
}