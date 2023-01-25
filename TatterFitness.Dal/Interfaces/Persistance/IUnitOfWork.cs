using Microsoft.EntityFrameworkCore.Storage;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Repositories;

namespace TatterFitness.Dal.Interfaces.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ExerciseEntity> Exercises { get; }
        IRoutineExerciseRepository RoutineExercises { get; }
        IRoutinesRepository Routines { get; }
        IGenericRepository<UserEntity> Users { get; }
        IWorkoutRepository Workouts { get; }
        IWorkoutExerciseRepository WorkoutExercises { get; }
        IVideoRepository Videos { get; }
        IGenericRepository<ExerciseModifierEntity> ExerciseModifiers { get; }
        IGenericRepository<WorkoutExerciseModifierEntity> WorkoutExerciseModifiers { get; }
        IGenericRepository<WorkoutExerciseSetEntity> WorkoutExerciseSets { get; }
        void Detach<T>(T entity) where T : class;
        int Complete();
        void ExecuteSql(string sql);
        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

    }
}
