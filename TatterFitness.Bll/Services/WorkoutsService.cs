using AutoMapper;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Services
{
    public class WorkoutsService : DataService, IWorkoutsService
    {
        public WorkoutsService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        }

        public void Update(Workout workout)
        {
            var workoutEntity = ValidateAccessToWorkout(workout.Id);
            workoutEntity.Name = workout.Name;

            uow.Workouts.Update(workoutEntity);
            uow.Complete();
        }

        public void Delete(int workoutId)
        {
            var workout = ValidateAccessToWorkout(workoutId);
            uow.Workouts.Delete(workout);
        }

        public Workout Create(Workout workout)
        {
            var workoutEntity = mapper.Map<WorkoutEntity>(workout);
            workoutEntity.Date = DateTime.Now;
            workoutEntity.UserId = CurrentUserId;

            workoutEntity = uow.Workouts.Create(workoutEntity);
            uow.Complete();

            return mapper.Map<Workout>(workoutEntity);
        }

        public Workout Read(int workoutId)
        {
            ValidateAccessToWorkout(workoutId);
            var workoutEntity = uow.Workouts.ReadWorkout(workoutId, CurrentUserId);
            var workout = mapper.Map<WorkoutEntity, Workout>(workoutEntity);

            return workout;
        }
    }
}
