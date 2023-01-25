using TatterFitness.Models.Exercises;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IExercisesService
    {
        IEnumerable<Exercise> ReadAllExercises();
        Exercise ReadExercise(int exerciseId);
        void DeleteExercise(int exerciseId);
    }
}
