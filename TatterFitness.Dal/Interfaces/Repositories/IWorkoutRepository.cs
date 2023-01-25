using TatterFitness.Dal.Entities;

namespace TatterFitness.Dal.Interfaces.Repositories
{
    public interface IWorkoutRepository : IGenericRepository<WorkoutEntity>
    {
        IEnumerable<WorkoutEntity> ReadByExercise(int exerciseId, int userId);
        WorkoutEntity ReadWorkout(int workoutId, int userId);
        IEnumerable<WorkoutEntity> ReadWorkouts(DateTime inclusiveFrom, DateTime inclusiveTo);
    }
}
