using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IWorkoutExerciseSetsService
    {
        WorkoutExerciseSet Create(WorkoutExerciseSet set);
        void Delete(int workoutExerciseSetId);
        WorkoutExerciseSet Update(WorkoutExerciseSet set);
    }
}
