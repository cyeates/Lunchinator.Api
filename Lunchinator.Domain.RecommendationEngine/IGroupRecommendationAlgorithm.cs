using System.Collections.Generic;
using Lunchinator.Data.Entities;

namespace Lunchinator.Domain
{
    public interface IGroupRecommendationAlgorithm
    {
        Dictionary<string, double> GetRecommendations(Lunch lunch);
    }
}