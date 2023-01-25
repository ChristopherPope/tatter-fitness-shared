using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IWorkoutExercisesService
    {
        void Delete(int workoutExerciseId);
        WorkoutExercise Create(WorkoutExercise workoutExercise);
        IEnumerable<WorkoutExercise> ReadMostRecent(IEnumerable<int> exerciseIds);
        void Update(WorkoutExercise workoutExercise);
        WorkoutExercise Read(int workoutExerciseId);
    }
}
