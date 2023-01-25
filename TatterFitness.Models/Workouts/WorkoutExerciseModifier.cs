namespace TatterFitness.Models.Workouts
{
    public class WorkoutExerciseModifier
    {
        public int WorkoutExerciseId { get; set; }
        public int ExerciseModifierId { get; set; }
        public int Id { get; set; }
        public string ModifierName { get; set; } = string.Empty;
        public int ModifierSequence { get; set; }
    }
}
