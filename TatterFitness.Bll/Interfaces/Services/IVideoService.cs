using TatterFitness.Dal.Entities;
using TatterFitness.Models.Enums;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IVideoService
    {
        bool DoesVideoExist(byte[] hash);
        byte[] ReadVideoData(int videoId);
        VideoEntity Create(VideoEntity entity);
        IQueryable<WorkoutVideos> ReadWorkoutVideos();
        IEnumerable<string> MakeSummaries(IEnumerable<WorkoutExerciseSet> sets, ExerciseTypes exerciseType);
    }
}
