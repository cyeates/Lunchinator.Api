using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunchinator.Data.Entities;

namespace Lunchinator.Domain
{
    public class AverageOfRatings : IGroupRecommendationAlgorithm
    {
        private readonly Recommendation _recommendation;

        public AverageOfRatings(Recommendation recommendation)
        {
            _recommendation = recommendation;
        }

         public Dictionary<string, double> GetRecommendations(Lunch lunch)
         {
             //List<User> users, List<string> items
             var items = lunch.Businesses.Select(b => b.Id).ToList();
             var sumOfRatings = GetSumOfRatings(lunch.Users, items);

             var averageRatings = GetAverageRatings(items, sumOfRatings);

             return averageRatings.OrderByDescending(a => a.Value).ToDictionary(a => a.Key, a => a.Value);

         }

        private static Dictionary<string, double> GetAverageRatings(List<string> items, Dictionary<string, double> sumOfRatings)
        {
            var averageRatings = new Dictionary<string, double>();
            int countOfItems = items.Count();
            foreach (var item in items)
            {
                averageRatings[item] = sumOfRatings[item]/countOfItems;
            }
            return averageRatings;
        }

        private Dictionary<string, double> GetSumOfRatings(List<User> users, List<string> items)
        {
            var sumOfRatings = new Dictionary<string, double>();
            foreach (var item in items)
            {
                sumOfRatings[item] = 0;
                foreach (var user in users)
                {
                    var predictedRatings = _recommendation.GetRecommendations(users, user);
                    if (user.ContainsRating(item))
                    {
                        sumOfRatings[item] += user.GetRating(item);
                    }
                    else
                    {
                        sumOfRatings[item] += predictedRatings[item];
                    }
                }
            }
            return sumOfRatings;
        }
    }
}
