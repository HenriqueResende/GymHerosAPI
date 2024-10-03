using AutoMapper;

namespace GymHerosAPI.Model.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<Workout, WorkoutDto>();
            CreateMap<WorkoutReg, Workout>();

            CreateMap<ExerciseTemplate, ExerciseTemplateDto>();
            CreateMap<ExerciseTemplateReg, ExerciseTemplate>();

            CreateMap<Exercise, ExerciseDto>();
            CreateMap<ExerciseReg, Exercise>();

            CreateMap<Series, SeriesDto>();
            CreateMap<SeriesReg, Series>();

            CreateMap<WorkoutHistory, WorkoutHistoryDto>();
            CreateMap<WorkoutHistoryReg, WorkoutHistory>();

            CreateMap<ExerciseHistory, ExerciseHistoryDto>();
            CreateMap<ExerciseHistoryReg, ExerciseHistory>();

            CreateMap<SeriesHistory, SeriesHistoryDto>();
            CreateMap<SeriesHistoryReg, SeriesHistory>();

            CreateMap<User, UserDto>();
            CreateMap<UserReg, User>();
        }
    }
}
