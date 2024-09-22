namespace GymHerosAPI.Model
{
    public class WorkoutHistoryDto
    {
        public int? Id { get; set; }

        public int? WorkoutId { get; set; }

        public int? Duration { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
