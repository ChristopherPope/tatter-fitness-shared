using TatterFitness.Models.Exercises;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IRoutineExercisesService
    {
        void Delete(int routineId, IEnumerable<int> exerciseIds);
        IEnumerable<RoutineExercise> Create(int routineId, IEnumerable<int> exerciseIds);
    }
}
