using TatterFitness.Models;
using TatterFitness.Models.Exercises;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IHistoriesService
    {
        IEnumerable<ExerciseHistory> ReadByExercise(int exerciseId);
        List<EventDay> ReadWorkoutEvents(WorkoutDateRange dateRange);
        IEnumerable<Workout> ReadWorkouts(WorkoutDateRange dateRange);
        WorkoutDateRange ReadFirstAndLastWorkoutDates();
    }
}
