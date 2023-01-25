
using TatterFitness.Models;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IRoutinesService
    {
        Routine CreateRoutine(Routine routine);
        Routine ReadRoutine(int routineId);
        void DeleteRoutine(int routineId);
        void UpdateRoutine(Routine routine);
        IEnumerable<Routine> ReadRoutines();
    }
}
