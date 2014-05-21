using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunchinator.Data.Entities;

namespace Lunchinator.Domain
{
    public class Recommendation
    {
        private readonly ISimilarityAlgorithm _similarityAlgorithm;

       
        public Recommendation(ISimilarityAlgorithm similarityAlgorithm)
        {
            _similarityAlgorithm = similarityAlgorithm;
        }

        /// <summary>
        /// Gets recommendations for a person.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public Dictionary<string, double> GetRecommendations(List<User> users, User person)
        {
            var totals = new Dictionary<string, double>();
            var sumOfSimilarities = new Dictionary<string, double>();

            foreach(var user in users)
            {
                //dont compare person to themself
                if (user.UserId == person.UserId) continue;

                var similarity = _similarityAlgorithm.CalculateSimilarity(person, user);

                //ignore scores of 0 or lower
                if (similarity <= 0) continue;

                //only get recommendations for items the person has not rated yet
                //foreach (var key in user.Ratings.Where(key => !person.ContainsRating(key)  || person.Ratings[key] == 0))
                foreach(var rating in user.Ratings.Where(r => !person.ContainsRating(r.RestaurantId) || person.GetRating(r.RestaurantId) == 0))
                {


                    string key = rating.RestaurantId;

                    if (!totals.ContainsKey(key))
                    {
                        totals[key] = 0;
                    }

                    totals[key] += user.GetRating(key)*similarity;

                    if (!sumOfSimilarities.ContainsKey(key))
                    {
                        sumOfSimilarities[key] = 0;
                    }

                    sumOfSimilarities[key] += similarity;
                }

               
            }

            var rankings = new Dictionary<string, double>();
            foreach (var key in totals.Keys)
            {
                rankings[key] = totals[key] / sumOfSimilarities[key];
            }

            return rankings.OrderByDescending(r => r.Value).ToDictionary(r => r.Key, r => r.Value);
        }


    }
}
