using AutoMapper;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models;

namespace TatterFitness.Bll.Services
{
    public class RoutinesService : DataService, IRoutinesService
    {
        public RoutinesService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        }

        public IEnumerable<Routine> ReadRoutines()
        {
            var routineEntities = uow.Routines.Read(r => r.UserId == CurrentUserId, rq => rq.OrderBy(r => r.Name));
            return mapper.Map<IEnumerable<RoutineEntity>, IEnumerable<Routine>>(routineEntities).ToList();
        }

        public Routine ReadRoutine(int routineId)
        {
            ValidateAccessToRoutine(routineId);
            var routineEntity = uow.Routines.ReadRoutine(routineId);
            var routineDto = mapper.Map<RoutineEntity, Routine>(routineEntity);

            return routineDto;
        }

        public Routine CreateRoutine(Routine routine)
        {
            var routineEntity = mapper.Map<Routine, RoutineEntity>(routine);
            routineEntity.UserId = CurrentUserId;
            routineEntity = uow.Routines.Create(routineEntity);
            uow.Complete();
            routine = mapper.Map<RoutineEntity, Routine>(routineEntity);

            return routine;
        }

        public void UpdateRoutine(Routine routine)
        {
            var routineEntity = ValidateAccessToRoutine(routine.Id);
            routineEntity.Name = routine.Name;
            uow.Routines.Update(routineEntity);
            uow.Complete();
        }

        public void DeleteRoutine(int routineId)
        {
            var routineEntity = ValidateAccessToRoutine(routineId);
            uow.Routines.Delete(routineEntity);
            uow.Complete();
        }
    }
}
