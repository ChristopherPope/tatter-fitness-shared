using AutoMapper;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models.Exercises;

namespace TatterFitness.Bll.Services
{
    public class ExerciseModifiersService : DataService, IExerciseModifiersService
    {
        public ExerciseModifiersService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        }

        public IEnumerable<ExerciseModifier> ReadModifiers()
        {
            var modEntities = uow.ExerciseModifiers.Read();

            return mapper.Map<IEnumerable<ExerciseModifier>>(modEntities);
        }
    }
}
