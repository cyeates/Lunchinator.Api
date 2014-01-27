using Lunchinator.Data;
using Lunchinator.Domain;
using Lunchinator.Domain.BusinessApi;
using Lunchinator.Domain.Services;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Lunchinator.Api
{
  public static class UnityConfig
  {
    public static void RegisterComponents()
    {
      var container = new UnityContainer();

      container.RegisterType<LunchinatorContext, LunchinatorContext>();

      //recommendation engine
      container.RegisterType<IGroupRecommendationAlgorithm, AverageOfRatings>();
      container.RegisterType<ISimilarityAlgorithm, PearsonCorrelation>();
      container.RegisterType<Recommendation, Recommendation>();

      //service
      container.RegisterType<LunchService, LunchService>();
      container.RegisterType<UserService, UserService>();

      //restaurant api
      container.RegisterType<IBusinessApiProvider, YelpProvider>();

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}