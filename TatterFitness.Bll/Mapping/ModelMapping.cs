using AutoMapper;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Entities.Charts;
using TatterFitness.Models;
using TatterFitness.Models.Charts;
using TatterFitness.Models.Exercises;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Mapping
{
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            MapExercise();
            MapRoutine();
            MapWorkout();
            MapUser();
            MapChartData();
            MapModifiers();
            MapHistory();
        }

        private void MapHistory()
        {
            CreateMap<WorkoutEntity, ExerciseHistory>()
                .ForMember(dest => dest.WorkoutName, cfg => cfg.MapFrom(src => src.Name))
                .ForMember(dest => dest.WorkoutDate, cfg => cfg.MapFrom(src => src.Date))
                .ForMember(dest => dest.Notes, cfg =>
                    cfg.MapFrom(src => src.WorkoutExercises.Select(we => we.Notes).First()))
                .ForMember(dest => dest.ExerciseName, cfg =>
                    cfg.MapFrom(src => src.WorkoutExercises.Select(we => we.Exercise.Name).First()))
                .ForMember(dest => dest.ExerciseType, cfg =>
                    cfg.MapFrom(src => src.WorkoutExercises.Select(we => we.Exercise.ExerciseTypeId).First()))
                .ForMember(dest => dest.Sets, cfg =>
                    cfg.MapFrom(src => src.WorkoutExercises.SelectMany(we => we.WorkoutExerciseSets)))
                .ForMember(dest => dest.WorkoutId, cfg =>
                    cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.Mods, cfg =>
                    cfg.MapFrom(src => src.WorkoutExercises.SelectMany(we => we.WorkoutExerciseModifiers)));
        }

        private void MapChartData()
        {
            CreateMap<DailyValueEntity, DailyValue>();
        }

        private void MapWorkout()
        {
            CreateMap<WorkoutEntity, Workout>()
                .ForMember(dest => dest.Exercises, opt => opt.MapFrom(source => source.WorkoutExercises));

            CreateMap<Workout, WorkoutEntity>();

            CreateMap<WorkoutExerciseEntity, WorkoutExercise>()
                .ForMember(dest => dest.Sets, opt => opt.MapFrom(source => source.WorkoutExerciseSets))
                .ForMember(dest => dest.Mods, opt => opt.MapFrom(source => source.WorkoutExerciseModifiers))
                .ForMember(dest => dest.WorkoutDate, opt => opt.MapFrom(source => source.Workout.Date))
                .ForMember(dest => dest.ExerciseName, opt => opt.MapFrom(source => source.Exercise.Name))
                .ForMember(dest => dest.ExerciseType, opt => opt.MapFrom(source => source.Exercise.ExerciseTypeId));

            CreateMap<WorkoutExercise, WorkoutExerciseEntity>()
                .ForMember(dest => dest.WorkoutExerciseSets, opt => opt.MapFrom(source => source.Sets))
                .ForMember(dest => dest.WorkoutExerciseModifiers, opt => opt.MapFrom(source => source.Mods));

            CreateMap<WorkoutExerciseSetEntity, WorkoutExerciseSet>()
                .ForMember(dest => dest.ExerciseType, opt => opt.MapFrom(source => source.WorkoutExercise.Exercise.ExerciseTypeId))
                .ReverseMap();
        }

        private void MapUser()
        {
            CreateMap<UserEntity, User>();
        }

        private void MapModifiers()
        {
            CreateMap<ExerciseModifier, ExerciseModifierEntity>().ReverseMap();

            CreateMap<WorkoutExerciseModifier, WorkoutExerciseModifierEntity>();
            CreateMap<WorkoutExerciseModifierEntity, WorkoutExerciseModifier>()
                .ForMember(dest => dest.ModifierName, opt => opt.MapFrom(source => source.ExerciseModifier.Name))
                .ForMember(dest => dest.ModifierSequence, opt => opt.MapFrom(source => source.ExerciseModifier.Sequence));
        }

        private void MapExercise()
        {
            CreateMap<ExerciseEntity, Exercise>()
                .ForMember(dest => dest.ExerciseType, opt => opt.MapFrom(entity => entity.ExerciseTypeId));

            CreateMap<RoutineExercise, RoutineExerciseEntity>();
            CreateMap<RoutineExerciseEntity, RoutineExercise>()
                .ForMember(dest => dest.RoutineExerciseId, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.RoutineId, opt => opt.MapFrom(source => source.RoutineId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(source => source.Exercise.Id))
                .ForMember(dest => dest.ExerciseName, opt => opt.MapFrom(source => source.Exercise.Name))
                .ForMember(dest => dest.ExerciseType, opt => opt.MapFrom(source => source.Exercise.ExerciseTypeId));

            CreateMap<ExerciseModifierEntity, ExerciseModifier>();

            CreateMap<WorkoutExerciseEntity, Exercise>()
                .IncludeMembers(we => we.Exercise)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Exercise.Id));
        }

        private void MapRoutine()
        {
            CreateMap<RoutineEntity, Routine>()
                .ForMember(dest => dest.Exercises, opt => opt.MapFrom(source => source.RoutineExercises));

            CreateMap<Routine, RoutineEntity>();
        }
    }
}

