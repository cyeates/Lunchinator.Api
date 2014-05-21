using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lunchinator.Data.Entities;
using Lunchinator.Domain.Services;
using WebGrease.Css.Extensions;

namespace Lunchinator.Api.Controllers
{
    public class UsersController : ApiController
    {
        private UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        public HttpResponseMessage SaveRatings(IEnumerable<Rating> ratings)
        {
          var userId = new Guid("FD8F72E2-19C6-477C-A75A-493C83BED233");

          try
          {
            _userService.SaveRatings(ratings, userId);
            return Request.CreateResponse(HttpStatusCode.OK);
          }
          catch (Exception ex)
          {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
          }
         
        }

        public IEnumerable<Business> GetBusinessesToRate(Guid eventId)
        {
            var businesses = _userService.GetBusinessesToRateForEvent(eventId);
            return businesses;
        }

        
    }
}
