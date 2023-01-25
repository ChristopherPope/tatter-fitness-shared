using Microsoft.EntityFrameworkCore;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Repositories;

namespace TatterFitness.Dal.Persistence.Repositories
{
    public class VideoRepository : GenericRepository<VideoEntity>, IVideoRepository
    {
        public VideoRepository(TatterDb context)
            : base(context)
        {
        }

        public IEnumerable<VideoEntity> ReadAllVideosSansVideoData()
        {
            return (from v in entities
                            .Include(v => v.WorkoutExercise).ThenInclude(we => we.Workout)
                            .Include(v => v.WorkoutExercise).ThenInclude(we => we.Exercise)
                            .Include(v => v.WorkoutExercise).ThenInclude(we => we.WorkoutExerciseSets)
                    select new VideoEntity
                    {
                        Id = v.Id,
                        WorkoutExerciseId = v.WorkoutExerciseId,
                        WorkoutExercise = v.WorkoutExercise
                    })
                          .ToList();
        }

        public IEnumerable<int> ReadAllIds()
        {
            return entities.Select(v => v.Id).ToList();
        }
    }
}


