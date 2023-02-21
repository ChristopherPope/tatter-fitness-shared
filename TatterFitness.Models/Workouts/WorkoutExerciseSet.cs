using TatterFitness.Models.Enums;

namespace TatterFitness.Models.Workouts
{
    public class WorkoutExerciseSet
    {
        public int Id { get; set; }
        public int WorkoutExerciseId { get; set; }
        public int SetNumber { get; set; }
        public double MilesDistance { get; set; }
        public int MachineIntensity { get; set; }
        public double MachineWatts { get; set; }
        public int MachineIncline { get; set; }
        public int Calories { get; set; }
        public int MaxBpm { get; set; }
        public int DurationInSeconds { get; set; }
        public double Weight { get; set; }
        public int RepCount { get; set; }
        public double Volume { get; set; }
        public ExerciseTypes ExerciseType { get; set; }

        public string Key
        {
            get
            {
                return $"{WorkoutExerciseId}{MilesDistance}{MachineIntensity}{MachineWatts}{MachineIncline}{Calories}{DurationInSeconds}{Weight}{RepCount}{Volume}";
            }
        }

        public WorkoutExerciseSet()
        {
        }

        public WorkoutExerciseSet(int setNumber, ExerciseTypes exerciseType)
        {
            SetNumber = setNumber;
            switch (exerciseType)
            {
                case ExerciseTypes.Cardio:
                    DurationInSeconds = 60;
                    MilesDistance = 1;
                    break;

                case ExerciseTypes.DurationAndWeight:
                    DurationInSeconds = 30;
                    Weight = 50;
                    Volume = 50;
                    break;

                case ExerciseTypes.RepsOnly:
                    RepCount = 10;
                    break;

                case ExerciseTypes.RepsAndWeight:
                    RepCount = 10;
                    Weight = 25;
                    Volume = 250;
                    break;
            }
        }
    }
}
