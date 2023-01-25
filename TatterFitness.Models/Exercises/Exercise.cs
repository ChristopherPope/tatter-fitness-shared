using TatterFitness.Models.Enums;

namespace TatterFitness.Models.Exercises
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ExerciseTypes ExerciseType { get; set; }
    }
}
