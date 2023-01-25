using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Dal.Interfaces.Repositories;
using TatterFitness.Dal.Persistence.Repositories;

namespace TatterFitness.Dal.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TatterDb dbContext;

        public IGenericRepository<ExerciseEntity> Exercises { get; private set; }
        public IRoutineExerciseRepository RoutineExercises { get; private set; }
        public IRoutinesRepository Routines { get; private set; }
        public IGenericRepository<UserEntity> Users { get; private set; }
        public IWorkoutRepository Workouts { get; private set; }
        public IWorkoutExerciseRepository WorkoutExercises { get; private set; }
        public IVideoRepository Videos { get; private set; }
        public IGenericRepository<ExerciseModifierEntity> ExerciseModifiers { get; private set; }
        public IGenericRepository<WorkoutExerciseModifierEntity> WorkoutExerciseModifiers { get; private set; }
        public IGenericRepository<WorkoutExerciseSetEntity> WorkoutExerciseSets { get; private set; }

        public UnitOfWork(TatterDb dbContext)
        {
            this.dbContext = dbContext;
            Exercises = new GenericRepository<ExerciseEntity>(dbContext);
            RoutineExercises = new RoutineExerciseRepository(dbContext);
            Routines = new RoutinesRepository(dbContext);
            Users = new GenericRepository<UserEntity>(dbContext);
            Workouts = new WorkoutRepository(dbContext);
            WorkoutExercises = new WorkoutExerciseRepository(dbContext);
            Videos = new VideoRepository(dbContext);
            ExerciseModifiers = new GenericRepository<ExerciseModifierEntity>(dbContext);
            WorkoutExerciseModifiers = new GenericRepository<WorkoutExerciseModifierEntity>(dbContext);
            WorkoutExerciseSets = new GenericRepository<WorkoutExerciseSetEntity>(dbContext);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            dbContext.Database.RollbackTransaction();
        }

        public int Complete()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public void Detach<T>(T entity) where T : class
        {
            if (entity == null)
            {
                return;
            }

            dbContext.Entry(entity).State = EntityState.Detached;
        }

        public void ExecuteSql(string sql)
        {
            dbContext.Database.ExecuteSqlRaw(sql);
        }
    }
}
