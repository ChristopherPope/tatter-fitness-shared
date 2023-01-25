using AutoMapper;
using Newtonsoft.Json;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models.Enums;
using TatterFitness.Models.Workouts;

namespace TatterFitness.Bll.Services
{
    public class VideoService : DataService, IVideoService
    {
        public VideoService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
        } 

        public byte[] ReadVideoData(int videoId)
        {
            var video = ValidateAccessToVideo(videoId);

            return video.VideoData;
        }

        public VideoEntity Create(VideoEntity entity)
        {
            entity = uow.Videos.Create(entity);
            uow.Complete();

            return entity;
        }

        public bool DoesVideoExist(byte[] hash)
        {
            return uow.Videos.Read(v => v.Hash == hash).Any();
        }

        public IQueryable<WorkoutVideos> ReadWorkoutVideos()
        {
            var videoGroups = uow.Videos
                .ReadAllVideosSansVideoData()
                .GroupBy(v => v.WorkoutExercise)
                .ToDictionary(group => group.Key, group => group.ToList());

            var workoutVideos = new List<WorkoutVideos>();
            foreach (var videoGroup in videoGroups)
            {
                var workoutExercise = mapper.Map<WorkoutExercise>(videoGroup.Key);

                var workout = new WorkoutVideos
                {
                    WorkoutDate = workoutExercise.WorkoutDate,
                    ExerciseName = workoutExercise.ExerciseName,
                    VideoIds = JsonConvert.SerializeObject(videoGroup.Value.Select(v => v.Id)),
                    SetSummaries = MakeSummaries(workoutExercise.Sets, workoutExercise.ExerciseType)
                };

                workoutVideos.Add(workout);
            }

            return workoutVideos
                .OrderByDescending(v => v.WorkoutDate)
                .AsQueryable();
        }

        public IEnumerable<string> MakeSummaries(IEnumerable<WorkoutExerciseSet> sets, ExerciseTypes exerciseType)
        {
            var summaries = new List<string>();
            var setGroups = sets.GroupBy(s => s.Key);
            foreach (var setGroup in setGroups)
            {
                summaries.Add(MakeSetSummary(setGroup, exerciseType));
            }

            return summaries;
        }

        private string MakeSetSummary(IEnumerable<WorkoutExerciseSet> setGroup, ExerciseTypes exerciseType)
        {
            var firstSet = setGroup.First();
            return exerciseType switch
            {
                ExerciseTypes.RepsAndWeight => $"{setGroup.Count()} x {firstSet.RepCount} @{firstSet.Weight} lbs.",
                ExerciseTypes.RepsOnly => $"{setGroup.Count()} x {firstSet.RepCount}",
                ExerciseTypes.DurationAndWeight => $"{setGroup.Count()} x {TimeSpan.FromSeconds(firstSet.DurationInSeconds)} @{firstSet.Weight} lbs.",
                ExerciseTypes.Cardio => $"{setGroup.Count()} x {TimeSpan.FromSeconds(firstSet.DurationInSeconds)} @{firstSet.MilesDistance} mi.",
                _ => String.Empty,
            };
        }
    }
}
