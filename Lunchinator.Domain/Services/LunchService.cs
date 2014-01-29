using System.Configuration;
using System.Net;
using System.Net.Mail;
using Lessthanchad.Email;
using Lunchinator.Data.Contracts;
using Lunchinator.Data.Entities;

using Lunchinator.Domain.BusinessApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGridMail;
using SendGridMail.Transport;

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
      if (lunch == null)
        return;

      var user = new User {LunchId = lunchId, EmailAddress = emailAddress};
      lunch.Users.Add(user);
      _uow.Commit();

      var email = new Lessthanchad.Email.Email(EmailSettings.GetEmailSettings());
      email.Subject = "You've been invited to lunch!";
      email.Body = String.Format(ConfigurationManager.AppSettings["AppBaseUrl"] + "#/ratings/{0}", lunch.LunchId.ToString());
      email.Recipients = new List<string>{emailAddress};
      email.Send();
      

    }

    public Business GetRecommendation(Guid id)
    {
      var lunch = _uow.Lunches.GetAll().FirstOrDefault(l => l.LunchId == id);
      var recommendations = _groupRecommendation.GetRecommendations(lunch);
      return lunch.Businesses.FirstOrDefault(b => b.Id == recommendations.ElementAt(0).Key);
    }


  }
}
