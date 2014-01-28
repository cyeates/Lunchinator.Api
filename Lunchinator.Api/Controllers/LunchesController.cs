using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lunchinator.Api.Models;
using Lunchinator.Data.Entities;
using Lunchinator.Domain;
using Lunchinator.Domain.Services;

namespace Lunchinator.Api.Controllers
{
  public class LunchesController : ApiController
  {
    private readonly LunchService _lunchService;
    
    public LunchesController(LunchService lunchService)
    {
      _lunchService = lunchService;
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
      return Request.CreateResponse(HttpStatusCode.OK);
    }

    public Business GetRecommendation(Guid lunchId)
    {
      return _lunchService.GetRecommendation(lunchId);
    }
  }
}