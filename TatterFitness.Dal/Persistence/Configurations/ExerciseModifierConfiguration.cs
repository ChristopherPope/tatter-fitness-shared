﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Persistance;

#nullable disable

namespace TatterFitness.Dal.Persistance.Configurations
{
    public partial class ExerciseModifierConfiguration : IEntityTypeConfiguration<ExerciseModifierEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseModifierEntity> entity)
        {
            entity.ToTable("ExerciseModifiers");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ExerciseModifierEntity> entity);
    }
}
