using TatterFitness.Models.Enums;

namespace TatterFitness.Models.Workouts
{
    public class WorkoutExercise
    {
        public WorkoutExercise()
        {
        }

        private int id;

        public int Id
        {
            get => id;
            set => id = value;
        }
        public int WorkoutId { get; set; }
        public DateTime WorkoutDate { get; set; }
        public int ExerciseId { get; set; }
        public int FtoWeekNumber { get; set; }
        public int FtoTrainingMax { get; set; }
        public int Sequence { get; set; }
        public string? Notes { get; set; }
        public ExerciseTypes ExerciseType { get; set; }
        public string ExerciseName { get; set; } = string.Empty;
        public List<WorkoutExerciseSet> Sets { get; set; } = new List<WorkoutExerciseSet>();
        public List<WorkoutExerciseModifier> Mods { get; set; } = new List<WorkoutExerciseModifier>();
    }
}
