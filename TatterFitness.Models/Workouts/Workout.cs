﻿namespace TatterFitness.Models.Workouts
{
    public class Workout
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<WorkoutExercise> Exercises { get; set; } = new();
    }
}
