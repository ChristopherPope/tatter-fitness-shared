﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace TatterFitness.Dal.Entities
{
    public partial class RoutineEntity
    {
        public RoutineEntity()
        {
            RoutineExercises = new HashSet<RoutineExerciseEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserId { get; set; }

        public virtual UserEntity User { get; set; } = null!;
        public virtual ICollection<RoutineExerciseEntity> RoutineExercises { get; set; }
    }
}