using System;

namespace TatterFitness.Dal.Entities.Charts
{
    public class WorkoutExerciseDataEntity
    {
        public int WorkoutId { get; set; }
        public DateTime WorkoutDay { get; set; }
        public double Volume { get; set; }
        public int ExerciseId { get; set; }
        public int SetTypeId { get; set; }
    }
}
