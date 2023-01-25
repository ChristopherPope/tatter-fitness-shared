using AutoMapper;
using TatterFitness.Bll.Exceptions;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models.Exercises;

namespace TatterFitness.Bll.Services
{
    public class RoutineExercisesService : DataService, IRoutineExercisesService
    {
        public RoutineExercisesService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        }

        public IEnumerable<RoutineExercise> Create(int routineId, IEnumerable<int> exerciseIds)
        {
            var existingRoutineExercises = ReadRoutineExercises(routineId, exerciseIds);
            if (existingRoutineExercises.Any())
            {
                var existingExerciseIds = existingRoutineExercises.Select(re => re.ExerciseId).ToArray();
                var ids = string.Join(',', existingExerciseIds);

                throw new EntityAlreadyExistsException($"The following Exercise ids already exist in Routine id {routineId} - {ids}");
            }

            var newRoutineExerciseEntities = new List<RoutineExerciseEntity>();
            foreach (var exerciseId in exerciseIds)
            {
                var newRoutineExercise = new RoutineExercise { RoutineId = routineId, ExerciseId = exerciseId };
                var newRoutineExerciseEntity = mapper.Map<RoutineExerciseEntity>(newRoutineExercise);
                newRoutineExerciseEntities.Add(uow.RoutineExercises.Create(newRoutineExerciseEntity));
            }
            
            uow.Complete();

            newRoutineExerciseEntities = uow.RoutineExercises.ReadRoutineExercises(newRoutineExerciseEntities.Select(re => re.Id)).ToList();
            return mapper.Map<IEnumerable<RoutineExercise>>(newRoutineExerciseEntities);
        }

        public void Delete(int routineId, IEnumerable<int> exerciseIds)
        {
            var routineExercises = ReadRoutineExercises(routineId, exerciseIds);
            var nonExistentExerciseIds = exerciseIds.Except(routineExercises.Select(re => re.ExerciseId)).ToList();

            if (nonExistentExerciseIds.Any())
            {
                var ids = string.Join(',', nonExistentExerciseIds);
                throw new EntityNotFoundException($"The following Exercise ids do not exist in Routine id {routineId} - {ids}");
            }

            uow.RoutineExercises.Delete(routineExercises.ToArray());

            uow.Complete();
        }

        private List<RoutineExerciseEntity> ReadRoutineExercises(int routineId, IEnumerable<int> exerciseIds)
        {
            ValidateAccessToRoutine(routineId);
            return uow.RoutineExercises.Read(re => re.RoutineId == routineId && exerciseIds.Contains(re.ExerciseId)).ToList();
        }
    }
}
