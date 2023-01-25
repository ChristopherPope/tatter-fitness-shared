using TatterFitness.Dal.Entities;

namespace TatterFitness.Dal.Interfaces.Repositories
{
    public interface IRoutineExerciseRepository : IGenericRepository<RoutineExerciseEntity>
    {
        IEnumerable<RoutineExerciseEntity> ReadRoutineExercises(IEnumerable<int> routineExerciseIds);
    }
}
