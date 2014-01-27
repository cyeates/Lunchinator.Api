using Lunchinator.Data.Entities;

namespace Lunchinator.Domain
{
    public interface ISimilarityAlgorithm
    {
        double CalculateSimilarity(User p1, User p2);
    }
}