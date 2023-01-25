using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IWorkoutsService
    {
        Workout Create(Workout workout);
        void Update(Workout workout);
        void Delete(int workoutId);
        Workout Read(int workoutId);
    }
}
