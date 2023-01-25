using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IWorkoutExerciseModifiersService
    {
        WorkoutExerciseModifier Create(WorkoutExerciseModifier modifier);
        void Delete(int workoutExerciseModifierId);
    }
}
