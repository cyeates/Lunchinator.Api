using Lunchinator.Data.Contracts;
using Lunchinator.Data.Entities;

using Lunchinator.Domain.BusinessApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Domain.Services
{
  public class LunchService
  {
    private IUnitOfWork _uow;
    private IGroupRecommendationAlgorithm _groupRecommendation;
    public IBusinessApiProvider _api { get; set; }

    public LunchService(IBusinessApiProvider api, IUnitOfWork uow, IGroupRecommendationAlgorithm groupRecommendation)
    {
      _api = api;
      _uow = uow;
      _groupRecommendation = groupRecommendation;
    }

    public Lunch CreateLunch(Lunch lunch, SearchParameters searchParameters)
    {
      var businesses = _api.GetBusinessesForEvent(searchParameters);

      //var lunch = new Lunch {Description = "testing" };
      lunch.Businesses.AddRange(businesses);

      _uow.Lunches.Add(lunch);
      _uow.Commit();

      return lunch;


    }

    public void InviteUser(Guid lunchId, string emailAddress)
    {
      var lunch = _uow.Lunches.GetById(lunchId);
      lunch.Users.Add(new User{LunchId = lunchId, EmailAddress = emailAddress});
      _uow.Commit();
    }

    public Business GetRecommendation(Guid id)
    {
      var lunch = _uow.Lunches.GetAll().FirstOrDefault(l => l.LunchId == id);
      var recommendations = _groupRecommendation.GetRecommendations(lunch);
      return lunch.Businesses.FirstOrDefault(b => b.Id == recommendations.ElementAt(0).Key);
    }


  }
}
