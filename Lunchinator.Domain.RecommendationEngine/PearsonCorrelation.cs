using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunchinator.Data.Entities;

namespace Lunchinator.Domain
{
    public class PearsonCorrelation : ISimilarityAlgorithm
    {
        /// <summary>
        /// Uses Pearson Correlation coefficient to determine the similarity between two people based on their ratings.
        /// </summary>
        /// <param name="person1"></param>
        /// <param name="person2"></param>
        /// <returns></returns>
        public double CalculateSimilarity(User person1, User person2)
        {
            var mutuallyRatedItems = GetMutuallyRatedItems(person1, person2);
            var numberOfMutuallyRatedItems = mutuallyRatedItems.Count;

            if (numberOfMutuallyRatedItems == 0) return 0;

            double sum1 = 0, sum2 = 0, sum1Sq = 0, sum2Sq = 0, pSum = 0;
            foreach (var key in mutuallyRatedItems.Keys)
            {
                sum1 += person1.GetRating(key);
                sum2 += person2.GetRating(key);

                sum1Sq += Math.Pow(person1.GetRating(key), 2);
                sum2Sq += Math.Pow(person2.GetRating(key), 2);

                pSum += person1.GetRating(key) * person2.GetRating(key);
            }


            double num = 0;
            num = pSum - (sum1 * sum2 / numberOfMutuallyRatedItems);

            double den = 0;
            den = Math.Sqrt((sum1Sq - Math.Pow(sum1, 2) / numberOfMutuallyRatedItems) * (sum2Sq - Math.Pow(sum2, 2) / numberOfMutuallyRatedItems));

            if (den == 0) return 0;

            return num / den;

        }

        private static Dictionary<string, int> GetMutuallyRatedItems(User p1, User p2)
        {
            var mutuallyRatedItems = new Dictionary<string, int>();

            foreach (var rating in p1.Ratings)
            {
                if (p2.ContainsRating(rating.RestaurantId))
                {
                    mutuallyRatedItems[rating.RestaurantId] = 1;
                }
            }

            return mutuallyRatedItems;
        }
    }
}
