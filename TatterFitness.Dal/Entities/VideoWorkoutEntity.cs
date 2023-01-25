namespace TatterFitness.Dal.Entities
{
    public class VideoWorkoutEntity
    {
        public DateTime WorkoutDate { get; set; }
        public string ExerciseName { get; set; } = String.Empty;
        public int VideoId {get; set;}
    }
}
