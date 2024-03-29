﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace TatterFitness.Dal.Entities
{
    public partial class WorkoutExerciseEntity
    {
        public WorkoutExerciseEntity()
        {
            Videos = new HashSet<VideoEntity>();
            WorkoutExerciseModifiers = new HashSet<WorkoutExerciseModifierEntity>();
            WorkoutExerciseSets = new HashSet<WorkoutExerciseSetEntity>();
        }

        public int Id { get; set; }
        public int? FtoTrainingMax { get; set; }
        public int? FtoWeekNumber { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public int Sequence { get; set; }
        public string? Notes { get; set; }

        public virtual ExerciseEntity Exercise { get; set; } = null!;
        public virtual WorkoutEntity Workout { get; set; } = null!;
        public virtual ICollection<VideoEntity> Videos { get; set; }
        public virtual ICollection<WorkoutExerciseModifierEntity> WorkoutExerciseModifiers { get; set; }
        public virtual ICollection<WorkoutExerciseSetEntity> WorkoutExerciseSets { get; set; }
    }
}