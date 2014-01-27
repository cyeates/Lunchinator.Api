using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpSharp;
using YelpSharp.Data.Options;
using Lunchinator.Domain.Extensions;
using Lunchinator.Data.Entities;
namespace Lunchinator.Domain.BusinessApi
{
    public class YelpProvider : IBusinessApiProvider
    {
        private Yelp _yelp;
        public YelpProvider()
        {
            var options = new Options
                                {
                                  ConsumerKey="iMWjxq5tkkak9R6oNcfvZA",
                                  ConsumerSecret = "q9zS69YZ-wzU7X3SLHeE_Cp6Dzs",
                                  AccessToken = "zQSusjnIb4UTCaCXPAn1dUsOqgeF2Rjr",
                                  AccessTokenSecret = "wQiStPy4HaKldozaQ56pKEPH6vM"
                                };
            _yelp = new Yelp(options);
        }

        public IEnumerable<Business> GetBusinessesForEvent(SearchParameters search)
        {
            var options = new YelpSharp.Data.Options.SearchOptions
                                {
                                    GeneralOptions = new GeneralOptions{term="restaurants",  limit=20, offset=0, sort=2, radius_filter=4000},
                                    LocationOptions = new LocationOptions { location = search.Location, coordinates = new CoordinateOptions { latitude = search.Latitude, longitude = search.Longitude} }

                               };
           //var results =  _yelp.Search(options);

           //var lunchinatorBusinesses = new List<Business>();
           //foreach (var business in results.businesses)
           //{
           //    var mapper = new YelpBusinessToLunchinatorBusinessMapper();
           //    lunchinatorBusinesses.Add(mapper.Map(business));
           //}

           // //yelp limits each request to 20 results, which doesn't seem like enough, so i'm going to request the 2nd page.  surely 40 is enough.
           //if (results.total > 20)
           //{
           //    options.GeneralOptions.offset = 20;
           //    var results2 = _yelp.Search(options);
           //    foreach (var business in results2.businesses)
           //    {
           //        var mapper = new YelpBusinessToLunchinatorBusinessMapper();
           //        lunchinatorBusinesses.Add(mapper.Map(business));
           //    }
           //}

          // return lunchinatorBusinesses.Randomize().Where(b => b.Rating >= 3.0).Take(10).ToList();
          return null;
           
        }
    }
}
