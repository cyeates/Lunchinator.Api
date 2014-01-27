using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunchinator.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Lunchinator.Tests.Domain
{
    [TestClass]
    public class RecommendationTests
    {

        [TestMethod]
        public void ShouldCalculateRecommendation()
        {
            var users = TestData.GetTestUsers();
            var similarity = new PearsonCorrelation();
            var recommendation = new Recommendation(similarity);
            var user = users[6];

            var recommendations = recommendation.GetRecommendations(users, user);

            Assert.AreEqual(3.34779, Math.Round(recommendations.ElementAt(0).Value, 5));
            Assert.AreEqual(2.83255, Math.Round(recommendations.ElementAt(1).Value, 5));
            Assert.AreEqual(2.53098, Math.Round(recommendations.ElementAt(2).Value, 5));
        }
    }
}
