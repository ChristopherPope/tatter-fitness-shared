using AutoMapper;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Services
{
    public class WorkoutExerciseModifiersService : DataService, IWorkoutExerciseModifiersService
    {
        public WorkoutExerciseModifiersService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        }

        public WorkoutExerciseModifier Create(WorkoutExerciseModifier modifier)
        {
            ValidateAccessToWorkoutExercise(modifier.WorkoutExerciseId);
            ValidateAccessToExerciseModifier(modifier.ExerciseModifierId);

            var weModEntity = mapper.Map<WorkoutExerciseModifierEntity>(modifier);
            weModEntity = uow.WorkoutExerciseModifiers.Create(weModEntity);
            uow.Complete();

            return mapper.Map<WorkoutExerciseModifier>(weModEntity);
        }

        public void Delete(int workoutExerciseModifierId)
        {
            var weModEntity = ValidateAccessToWorkoutExerciseModifier(workoutExerciseModifierId);
            uow.WorkoutExerciseModifiers.Delete(weModEntity);
            uow.Complete();
        }
    }
}
