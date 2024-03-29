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
    public partial class VideoConfiguration : IEntityTypeConfiguration<VideoEntity>
    {
        public void Configure(EntityTypeBuilder<VideoEntity> entity)
        {
            entity.ToTable("Videos");

            entity.Property(e => e.Hash).HasMaxLength(50);

            entity.HasOne(d => d.WorkoutExercise)
                .WithMany(p => p.Videos)
                .HasForeignKey(d => d.WorkoutExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Videos_WorkoutExercises");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<VideoEntity> entity);
    }
}
