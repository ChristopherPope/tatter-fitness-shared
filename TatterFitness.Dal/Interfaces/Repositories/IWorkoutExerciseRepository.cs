using TatterFitness.Dal.Entities;

namespace TatterFitness.Dal.Interfaces.Repositories
{
    public interface IWorkoutExerciseRepository : IGenericRepository<WorkoutExerciseEntity>
    {
        IEnumerable<int> ReadMostRecentWorkoutExerciseIds(int userId, params int[] workoutExerciseIds);
        IEnumerable<WorkoutExerciseEntity> ReadWorkoutExercises(params int[] workoutExerciseIds);
    }
}
