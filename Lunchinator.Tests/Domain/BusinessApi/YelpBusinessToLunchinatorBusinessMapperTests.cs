using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpSharp;
using Moq;
using Lunchinator.Domain.BusinessApi;
namespace Lunchinator.Tests.Domain.BusinessApi
{
    [TestClass]
    public class YelpBusinessToLunchinatorBusinessMapperTests
    {
        [TestMethod]
        public void MapYelpBusinessToLunchinatorBusiness()
        {
            var yelpBusiness = new YelpSharp.Data.Business
                                    {
                                        id = "123",
                                        name = "Flaming Moe's",
                                        rating = 1.5,
                                        image_url = "www.google.com",
                                        location = new YelpSharp.Data.Location { display_address = new[] {"123 anywhere", "weatherford", "tx", "76086"} },
                                        url = "www.lunchinator.com"
                                    };
            var lunchinatorBusiness = new YelpBusinessToLunchinatorBusinessMapper().Map(yelpBusiness);

            Assert.AreEqual(yelpBusiness.id, lunchinatorBusiness.Id);
            Assert.AreEqual(yelpBusiness.name, lunchinatorBusiness.Name);
            Assert.AreEqual(yelpBusiness.rating, lunchinatorBusiness.Rating);
            Assert.AreEqual(yelpBusiness.image_url, lunchinatorBusiness.ImageUrl);
            Assert.AreEqual(yelpBusiness.location.display_address[0], lunchinatorBusiness.Address1);
            Assert.AreEqual(yelpBusiness.location.display_address[1], lunchinatorBusiness.Address2);
            Assert.AreEqual(yelpBusiness.url, lunchinatorBusiness.Url);
        }
    }
}
