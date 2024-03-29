﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace TatterFitness.Dal.Entities
{
    public partial class WorkoutExerciseSetEntity
    {
        public int Id { get; set; }
        public int WorkoutExerciseId { get; set; }
        public int SetNumber { get; set; }
        public double? MilesDistance { get; set; }
        public int? MachineIntensity { get; set; }
        public double? MachineWatts { get; set; }
        public int? MachineIncline { get; set; }
        public int? Calories { get; set; }
        public int? MaxBpm { get; set; }
        public int? DurationInSeconds { get; set; }
        public double? Weight { get; set; }
        public int? RepCount { get; set; }
        public double? Volume { get; set; }

        public virtual WorkoutExerciseEntity WorkoutExercise { get; set; } = null!;
    }
}