using Microsoft.EntityFrameworkCore;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Repositories;

namespace TatterFitness.Dal.Persistence.Repositories
{
    public class RoutineExerciseRepository : GenericRepository<RoutineExerciseEntity>, IRoutineExerciseRepository
    {
        public RoutineExerciseRepository(TatterDb context)
            : base(context)
        {
        }

        public IEnumerable<RoutineExerciseEntity> ReadRoutineExercises(IEnumerable<int> routineExerciseIds)
        {
            return (from re in entities.Include(re => re.Exercise)
                    where routineExerciseIds.Contains(re.Id)
                    select re).ToList();
        }
    }
}
