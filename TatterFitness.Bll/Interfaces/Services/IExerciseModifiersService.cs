using TatterFitness.Models.Exercises;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IExerciseModifiersService
    {
        IEnumerable<ExerciseModifier> ReadModifiers();
    }
}
