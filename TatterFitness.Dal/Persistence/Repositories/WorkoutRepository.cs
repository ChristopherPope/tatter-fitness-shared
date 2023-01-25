using Microsoft.EntityFrameworkCore;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Repositories;

namespace TatterFitness.Dal.Persistence.Repositories
{
    public class WorkoutRepository : GenericRepository<WorkoutEntity>, IWorkoutRepository
    {
        public WorkoutRepository(TatterDb context)
            : base(context)
        {
        }

        // todo: switch datetime to dateonly in db and code
        public IEnumerable<WorkoutEntity> ReadWorkouts(DateTime inclusiveFrom, DateTime inclusiveTo)
        {
            return entities
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.WorkoutExerciseModifiers)
                    .ThenInclude(wem => wem.ExerciseModifier)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.WorkoutExerciseSets.OrderBy(s => s.SetNumber))
                .Where(w => w.Date >= inclusiveFrom && w.Date <= inclusiveTo)
                .ToList();
        }

        public WorkoutEntity ReadWorkout(int workoutId, int userId)
        {
            return entities
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.WorkoutExerciseModifiers)
                    .ThenInclude(wem => wem.ExerciseModifier)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.WorkoutExerciseSets.OrderBy(s => s.SetNumber))
                .Where(w => w.Id == workoutId && w.UserId == userId)
                .AsNoTracking()
                .First();
        }

        public IEnumerable<WorkoutEntity> ReadByExercise(int exerciseId, int userId)
        {
            return (from w in entities
                    .Where(w => w.WorkoutExercises.Any(we => we.ExerciseId == exerciseId))
                .Include(w => w.WorkoutExercises.Where(we => we.ExerciseId == exerciseId))
                   .ThenInclude(we => we.WorkoutExerciseModifiers)
                   .ThenInclude(m => m.ExerciseModifier)
                .Include(w => w.WorkoutExercises.Where(we => we.ExerciseId == exerciseId))
                    .ThenInclude(we => we.WorkoutExerciseSets)
                    where w.UserId == userId
                    orderby w.Date descending
                    select w).ToList();
        }
    }
}
