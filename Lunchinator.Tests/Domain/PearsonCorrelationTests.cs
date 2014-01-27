using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunchinator.Data.Entities;
using Lunchinator.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lunchinator.Tests.Domain
{
    public class PearsonCorrelationTests
    {

        [TestMethod]
        public void CalculatePearsonCorrelation()
        {
            var users = TestData.GetTestUsers();
            var pearson = new PearsonCorrelation();

            var p1 = users[0];
            var p2 = users[1];
            var actual = pearson.CalculateSimilarity(p1, p2);

            var roundedActual = (decimal)Math.Round(actual, 5);
            Assert.AreEqual(roundedActual, 0.39606);



        }

        
    }
}

 
   