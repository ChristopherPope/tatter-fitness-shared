using TatterFitness.Models.Enums;

namespace TatterFitness.Models.Exercises
{
    public class RoutineExercise 
    {
        public List<ExerciseModifier> ExerciseModifiers { get; set; } = new List<ExerciseModifier>();
        public int RoutineExerciseId { get; set; }
        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }
        public string? ExerciseName { get; set; }
        public ExerciseTypes ExerciseType { get; set; }
    }
}
