using AutoMapper;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models.Exercises;

namespace TatterFitness.Bll.Services
{
    public class ExercisesService : DataService, IExercisesService
    {
        public ExercisesService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        }

        public IEnumerable<Exercise> ReadAllExercises()
        {
            var exerciseEntities = uow.Exercises.Read(null, e => e.OrderBy(ex => ex.Name));
            var exercises = mapper.Map<IEnumerable<ExerciseEntity>, IEnumerable<Exercise>>(exerciseEntities);

            return exercises.ToList();
        }

        public Exercise ReadExercise(int exerciseId)
        {
            var exerciseEntity = ValidateAccessToExercise(exerciseId);
            var exercise = mapper.Map<ExerciseEntity, Exercise>(exerciseEntity);

            return exercise;
        }

        public void DeleteExercise(int exerciseId)
        {
            var exercise = ValidateAccessToExercise(exerciseId);
            uow.Exercises.Delete(exercise);
            uow.Complete();
        }
    }
}
