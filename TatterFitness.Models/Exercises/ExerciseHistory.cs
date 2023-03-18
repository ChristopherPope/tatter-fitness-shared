using TatterFitness.Models.Enums;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Models.Exercises
{
    public class ExerciseHistory
    {
        public string WorkoutName { get; set; } = String.Empty;
        public DateTime WorkoutDate { get; set; }
        public string ExerciseName { get; set; } = String.Empty;
        public ExerciseTypes ExerciseType { get; set; }
        public IEnumerable<WorkoutExerciseSet> Sets { get; set; } = Enumerable.Empty<WorkoutExerciseSet>();
        public IEnumerable<WorkoutExerciseModifier> Mods { get; set; } = Enumerable.Empty<WorkoutExerciseModifier>();
        public int WorkoutId { get; set; }
        public int FtoTrainingMax { get; set; }
        public int FtoWeekNumber { get; set; }
        public string Notes { get; set; } = String.Empty;
    }
}
