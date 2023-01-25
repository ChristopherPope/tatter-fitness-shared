using TatterFitness.Dal.Entities;

namespace TatterFitness.Dal.Interfaces.Repositories
{
    public interface IVideoRepository : IGenericRepository<VideoEntity>
    {
        IEnumerable<int> ReadAllIds();
        IEnumerable<VideoEntity> ReadAllVideosSansVideoData();
    }
}
