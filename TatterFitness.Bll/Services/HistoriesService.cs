using AutoMapper;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models;
using TatterFitness.Models.Exercises;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Services
{
    public class HistoriesService : DataService, IHistoriesService
    {
        public HistoriesService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        }

        public IEnumerable<Workout> ReadWorkouts(WorkoutDateRange dateRange) // todo: move to workouts service
        {
            dateRange.InclusiveFrom = dateRange.InclusiveFrom.Date;
            dateRange.InclusiveTo = dateRange.InclusiveTo.AddDays(1).Date.AddSeconds(-1);
            var workouts = uow.Workouts.ReadWorkouts(dateRange.InclusiveFrom, dateRange.InclusiveTo);

            return mapper.Map<IEnumerable<Workout>>(workouts);
        }

        public List<EventDay> ReadWorkoutEvents(WorkoutDateRange dateRange)
        {
            dateRange.InclusiveFrom = dateRange.InclusiveFrom.Date;
            dateRange.InclusiveTo = dateRange.InclusiveTo.AddDays(1).Date.AddSeconds(-1);
            var events = uow.Workouts
                .Read(w => w.Date >= dateRange.InclusiveFrom && w.Date <= dateRange.InclusiveTo)
                .ToDictionary(w => w.Date, w => w.Id)
                .Select(f => new EventDay { EventDate = f.Key, EventId = f.Value })
                .ToList();

            return events;
        }

        public IEnumerable<ExerciseHistory> ReadByExercise(int exerciseId)
        {
            ValidateAccessToExercise(exerciseId);
            var history = uow.Workouts.ReadByExercise(exerciseId, CurrentUserId);

            return mapper.Map<IEnumerable<WorkoutEntity>, IEnumerable<ExerciseHistory>>(history);
        }

        public WorkoutDateRange ReadFirstAndLastWorkoutDates()
        {
            var firstWorkout = uow.Workouts.Read(w => w.UserId == CurrentUserId, q => q.OrderBy(w => w.Date)).FirstOrDefault();
            var lastWorkout = uow.Workouts.Read(w => w.UserId == CurrentUserId, q => q.OrderByDescending(w => w.Date)).FirstOrDefault();
            return new WorkoutDateRange
            {
                InclusiveFrom = firstWorkout?.Date ?? DateTime.Now,
                InclusiveTo = lastWorkout?.Date ?? DateTime.Now
            };
        }
    }
}
