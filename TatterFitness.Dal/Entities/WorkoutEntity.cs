﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace TatterFitness.Dal.Entities
{
    public partial class WorkoutEntity
    {
        public WorkoutEntity()
        {
            WorkoutExercises = new HashSet<WorkoutExerciseEntity>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; } 

        public virtual UserEntity User { get; set; } = null!;
        public virtual ICollection<WorkoutExerciseEntity> WorkoutExercises { get; set; }
    }
}