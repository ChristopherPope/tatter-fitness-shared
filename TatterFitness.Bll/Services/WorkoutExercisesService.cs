using AutoMapper;
using Newtonsoft.Json;
using TatterFitness.Bll.Exceptions;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Services
{
    public class WorkoutExercisesService : DataService, IWorkoutExercisesService
    {
        public WorkoutExercisesService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        }

        public WorkoutExercise Read(int workoutExerciseId)
        {
            var workoutExerciseEntity = ValidateAccessToWorkoutExercise(workoutExerciseId);
            return mapper.Map<WorkoutExercise>(workoutExerciseEntity);
        }

        public void Update(WorkoutExercise workoutExercise)
        {
            var workoutExerciseEntity = ValidateAccessToWorkoutExercise(workoutExercise.Id);
            mapper.Map(workoutExercise, workoutExerciseEntity);

            uow.WorkoutExercises.Update(workoutExerciseEntity);
            uow.Complete();
        }

        public WorkoutExercise Create(WorkoutExercise workoutExercise)
        {
            ValidateAccessToWorkout(workoutExercise.WorkoutId);
            ValidateAccessToExercise(workoutExercise.ExerciseId);

            var setNum = 1;
            foreach (var set in workoutExercise.Sets)
            {
                set.SetNumber = setNum++;
            }

            var workoutExerciseEntity = mapper.Map<WorkoutExerciseEntity>(workoutExercise);
            workoutExerciseEntity = uow.WorkoutExercises.Create(workoutExerciseEntity);
            uow.Complete();

            workoutExerciseEntity = uow.WorkoutExercises.ReadWorkoutExercises(workoutExerciseEntity.Id).First();
            return mapper.Map<WorkoutExercise>(workoutExerciseEntity);
        }

        public void Delete(int workoutExerciseId)
        {
            var workoutExerciseEntity = ValidateAccessToWorkoutExercise(workoutExerciseId);

            uow.WorkoutExercises.Delete(workoutExerciseEntity);
            uow.Complete();
        }

        public IEnumerable<WorkoutExercise> ReadMostRecent(IEnumerable<int> exerciseIds)
        {
            ValidateAccessToExercises(exerciseIds);
            var workoutExerciseIds = uow.WorkoutExercises.ReadMostRecentWorkoutExerciseIds(CurrentUserId, exerciseIds.ToArray()).ToArray();
            var weEntities = uow.WorkoutExercises.ReadWorkoutExercises(workoutExerciseIds).ToList();

            return mapper.Map<IEnumerable<WorkoutExercise>>(weEntities);
        }
    }
}
