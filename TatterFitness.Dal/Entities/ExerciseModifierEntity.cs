﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace TatterFitness.Dal.Entities
{
    public partial class ExerciseModifierEntity
    {
        public ExerciseModifierEntity()
        {
            WorkoutExerciseModifiers = new HashSet<WorkoutExerciseModifierEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Sequence { get; set; }

        public virtual ICollection<WorkoutExerciseModifierEntity> WorkoutExerciseModifiers { get; set; }
    }
}