using AutoMapper;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Services
{
    public class WorkoutExerciseSetsService : DataService, IWorkoutExerciseSetsService
    {
        public WorkoutExerciseSetsService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        }

        public WorkoutExerciseSet Create(WorkoutExerciseSet set)
        {
            ValidateAccessToWorkoutExercise(set.WorkoutExerciseId);

            var currentSetCount = uow.WorkoutExerciseSets.Read(s => s.WorkoutExerciseId == set.WorkoutExerciseId).Count();
            set.SetNumber = currentSetCount + 1;

            var setEntity = mapper.Map<WorkoutExerciseSetEntity>(set);
            setEntity = uow.WorkoutExerciseSets.Create(setEntity);
            uow.Complete();

            return mapper.Map<WorkoutExerciseSet>(setEntity);
        }

        public void Delete(int workoutExerciseSetId)
        {
            var set = ValidateAccessToWorkoutExerciseSet(workoutExerciseSetId);
            uow.WorkoutExerciseSets.Delete(set);
            RenumberSets(set.WorkoutExerciseId, set.Id);
            uow.Complete();
        }

        public WorkoutExerciseSet Update(WorkoutExerciseSet set)
        {
            var existingSetEntity = ValidateAccessToWorkoutExerciseSet(set.Id);
            set.WorkoutExerciseId = existingSetEntity.WorkoutExerciseId;
            uow.Detach(existingSetEntity);

            var setEntity = mapper.Map<WorkoutExerciseSetEntity>(set);
            setEntity = uow.WorkoutExerciseSets.Update(setEntity);
            uow.Complete();

            return mapper.Map<WorkoutExerciseSet>(setEntity);
        }

        private void RenumberSets(int workoutExerciseId, int ignoreSetId)
        {
            var sets = uow.WorkoutExerciseSets.Read(s => s.WorkoutExerciseId == workoutExerciseId);

            int setNumber = 1;
            foreach (var set in sets.OrderBy(s => s.SetNumber))
            {
                if (set.Id == ignoreSetId)
                {
                    continue;
                }

                set.SetNumber = setNumber++;
                uow.WorkoutExerciseSets.Update(set);
            }
        }
    }
}
