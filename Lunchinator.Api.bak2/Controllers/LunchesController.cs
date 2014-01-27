using System;
using System.Web.Http;
using Lunchinator.Data.Entities;
using Lunchinator.Domain;
using Lunchinator.Domain.Services;

namespace Lunchinator.Api.Controllers
{
    public class LunchesController : ApiController
    {
        private LunchService _lunchService;

      public LunchesController()
      {
       
      }
        public LunchesController(LunchService eventService)
        {
            _lunchService = eventService;
        }

        public string Create(Lunch lunch, SearchParameters searchParameters)
        {
            var createdLunch = _lunchService.CreateLunch(lunch, searchParameters);
            return createdLunch.LunchId.ToString();
        }

        public Business GetRecommendation(Guid eventId)
        {
            return _lunchService.GetRecommendation(eventId);
        }
    }
}