using AutoMapper;
using TatterFitness.Bll.Exceptions;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;

namespace TatterFitness.Bll.Services
{
    public abstract class DataService
    {
        protected readonly IUnitOfWork uow;
        protected readonly IMapper mapper;

        protected int CurrentUserId { get; } = 1;

        public DataService(IUnitOfWork uow
            , IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        protected VideoEntity ValidateAccessToVideo(int videoId)
        {
            var videoEntity = uow.Videos.Read(v => v.Id == videoId).FirstOrDefault();
            if (videoEntity == null)
            {
                throw new EntityNotFoundException($"VideoId {videoId} does not exist.");
            }

            return videoEntity;
        }

        protected RoutineEntity ValidateAccessToRoutine(int routineId)
        {
            var routineEntity = uow.Routines.Read(r => r.Id == routineId && r.UserId == CurrentUserId).FirstOrDefault();
            return ValidateAccessToRoutine(routineEntity, routineId);
        }

        protected RoutineEntity ValidateAccessToRoutine(RoutineEntity? routineEntity, int routineId)
        {
            if (routineEntity == null)
            {
                throw new EntityNotFoundException($"RoutineId {routineId} does not exist.");
            }

            return routineEntity;
        }

        protected RoutineExerciseEntity ValidateAccessToRoutineExercise(int routineExerciseId)
        {
            var routineExercise = uow.RoutineExercises.Read(re => re.Id == routineExerciseId).FirstOrDefault();
            if (routineExercise == null)
            {
                throw new EntityNotFoundException($"RoutineExerciseId {routineExerciseId} does not exist.");
            }

            ValidateAccessToRoutine(routineExercise.RoutineId);

            return routineExercise;
        }

        protected WorkoutEntity ValidateAccessToWorkout(int workoutId)
        {
            var workout = uow.Workouts.Read(w => w.Id == workoutId && w.UserId == CurrentUserId)
                .FirstOrDefault();

            if (workout == null)
            {
                throw new EntityNotFoundException($"WorkoutId {workoutId} does not exist.");
            }

            return workout;
        }

        protected WorkoutExerciseEntity ValidateAccessToWorkoutExercise(int workoutExerciseId)
        {
            var workoutExercise = uow.WorkoutExercises.ReadById(workoutExerciseId);
            if (workoutExercise == null)
            {
                throw new EntityNotFoundException($"WorkoutExerciseId {workoutExerciseId} does not exist.");
            }

            ValidateAccessToWorkout(workoutExercise.WorkoutId);

            return workoutExercise;
        }

        protected WorkoutExerciseSetEntity ValidateAccessToWorkoutExerciseSet(int workoutExerciseSetId)
        {
            var set = uow.WorkoutExerciseSets.ReadById(workoutExerciseSetId);
            if (set == null)
            {
                throw new EntityNotFoundException($"WorkoutExerciseSetId {workoutExerciseSetId} does not exist.");
            }

            ValidateAccessToWorkoutExercise(set.WorkoutExerciseId);

            return set;
        }

        protected ExerciseEntity ValidateAccessToExercise(int exerciseId)
        {
            var exercise = uow.Exercises.ReadById(exerciseId);
            if (exercise == null)
            {
                throw new EntityNotFoundException($"ExerciseId {exerciseId} does not exist.");
            }

            return exercise;
        }

        protected IEnumerable<ExerciseEntity> ValidateAccessToExercises(IEnumerable<int> exerciseIds)
        {
            var exercises = uow.Exercises.Read(e => exerciseIds.Contains(e.Id));

            var missingExerciseIds = exerciseIds.Except(exercises.Select(e => e.Id));
            if (missingExerciseIds.Any())
            {
                throw new EntityNotFoundException($"The following ExerciseIds do not exist: {string.Join(',', missingExerciseIds)}");
            }

            return exercises;
        }

        protected WorkoutExerciseModifierEntity ValidateAccessToWorkoutExerciseModifier(int workoutExerciseModifierId)
        {
            var weMod = uow.WorkoutExerciseModifiers.ReadById(workoutExerciseModifierId);
            if (weMod == null)
            {
                throw new EntityNotFoundException($"WorkoutExerciseModifierId {workoutExerciseModifierId} does not exist.");
            }

            ValidateAccessToWorkoutExercise(weMod.WorkoutExerciseId);

            return weMod;
        }

        protected ExerciseModifierEntity ValidateAccessToExerciseModifier(int exerciseModifierId)
        {
            var exMod = uow.ExerciseModifiers.ReadById(exerciseModifierId);
            if (exMod == null)
            {
                throw new EntityNotFoundException($"ExerciseModifierId {exerciseModifierId} does not exist.");
            }

            return exMod;
        }
    }
}
