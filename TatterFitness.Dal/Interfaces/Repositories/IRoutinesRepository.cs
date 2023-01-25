using TatterFitness.Dal.Entities;

namespace TatterFitness.Dal.Interfaces.Repositories
{
    public interface IRoutinesRepository : IGenericRepository<RoutineEntity>
    {
        RoutineEntity ReadRoutine(int routineId);
    }
}
