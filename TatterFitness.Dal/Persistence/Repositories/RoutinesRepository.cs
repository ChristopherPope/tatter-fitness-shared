using Microsoft.EntityFrameworkCore;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Repositories;

namespace TatterFitness.Dal.Persistence.Repositories
{
    public class RoutinesRepository : GenericRepository<RoutineEntity>, IRoutinesRepository
    {
        public RoutinesRepository(TatterDb context)
            : base(context)
        {
        }

        public RoutineEntity ReadRoutine(int routineId)
        {
            return entities
                .Include(r => r.RoutineExercises)
                .ThenInclude(re => re.Exercise)
                .Include(r => r.RoutineExercises.OrderBy(re => re.Exercise.Name))
                .Where(r => r.Id == routineId)
                .First();
        }
    }
}
