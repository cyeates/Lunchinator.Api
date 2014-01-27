using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunchinator.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lunchinator.Tests.Domain
{
    [TestClass]
    public class GroupRecommendationTests
    {
        [TestMethod]
        public void ShouldGetAverageOfRecommendation()
        {
            var similarity = new PearsonCorrelation();
            var recommendation = new Recommendation(similarity);
            var groupRecommendation = new AverageOfRatings(recommendation);

            
            var recommendations = groupRecommendation.GetRecommendations(TestData.GetTestLunch());

            Assert.AreEqual(4.66667, Math.Round(recommendations.ElementAt(0).Value, 5));
            Assert.AreEqual(4.33333, Math.Round(recommendations.ElementAt(1).Value, 5));
            Assert.AreEqual(3.97463, Math.Round(recommendations.ElementAt(2).Value, 5));
            Assert.AreEqual(3.25272, Math.Round(recommendations.ElementAt(3).Value, 5));
            Assert.AreEqual(2.94911, Math.Round(recommendations.ElementAt(4).Value, 5));
            Assert.AreEqual(2.83180, Math.Round(recommendations.ElementAt(5).Value, 5));
        }
    }
}
