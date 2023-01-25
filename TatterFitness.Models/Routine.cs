using TatterFitness.Models.Exercises;

namespace TatterFitness.Models
{
    public class Routine
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public IEnumerable<RoutineExercise> Exercises { get; set; } = new List<RoutineExercise>();
    }
}
