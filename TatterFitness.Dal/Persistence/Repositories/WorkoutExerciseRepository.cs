using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Repositories;

namespace TatterFitness.Dal.Persistence.Repositories
{
    class WorkoutExerciseRepository : GenericRepository<WorkoutExerciseEntity>, IWorkoutExerciseRepository
    {
        public WorkoutExerciseRepository(TatterDb context)
            : base(context)
        {
        }

        public IEnumerable<WorkoutExerciseEntity> ReadWorkoutExercises(params int[] workoutExerciseIds)
        {
            var workouts = context.Set<WorkoutEntity>();
            return (from we in entities
                            .Include(w => w.Exercise)
                            .Include(w => w.WorkoutExerciseSets)
                            .Include(w => w.WorkoutExerciseModifiers)
                            .ThenInclude(m => m.ExerciseModifier)
                    join w in workouts on we.WorkoutId equals w.Id
                    where workoutExerciseIds.Contains(we.Id)
                    select we)
                    .ToList();
        }

        public IEnumerable<int> ReadMostRecentWorkoutExerciseIds(int userId, params int[] exerciseIds)
        {
            var workoutExerciseIds = new List<int>();
            var connection = context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using var command = connection.CreateCommand();
            var param = command.CreateParameter();
            param.ParameterName = "exerciseIds";
            param.Value = string.Join(',', exerciseIds);
            command.Parameters.Add(param);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_GetLatestWorkoutExcerciseIds";
            command.Connection = connection;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                workoutExerciseIds.Add(reader.GetInt32(0));
            }

            return workoutExerciseIds;
        }
    }
}
