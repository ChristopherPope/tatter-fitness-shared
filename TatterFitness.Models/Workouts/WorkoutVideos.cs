namespace TatterFitness.Models.Workouts
{ 
    public class WorkoutVideos
    {
        public DateTime WorkoutDate { get; set; }
        public string ExerciseName { get; set; } = String.Empty;
        public IEnumerable<string> SetSummaries { get; set; } = Enumerable.Empty<string>();
        public string VideoIds { get; set; } = String.Empty;
    }
}
