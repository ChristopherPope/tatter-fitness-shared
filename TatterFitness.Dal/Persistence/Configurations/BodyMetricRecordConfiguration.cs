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
    public partial class BodyMetricRecordConfiguration : IEntityTypeConfiguration<BodyMetricRecordEntity>
    {
        public void Configure(EntityTypeBuilder<BodyMetricRecordEntity> entity)
        {
            entity.ToTable("BodyMetricRecords");
            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.User)
                .WithMany(p => p.BodyMetricRecords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BodyMetricRecords_Users");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<BodyMetricRecordEntity> entity);
    }
}