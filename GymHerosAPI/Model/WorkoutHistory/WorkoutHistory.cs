namespace GymHerosAPI.Model
{
    public class WorkoutHistory
    {
        public int? Id { get; set; }

        public int? IdUser { get; set; }

        public int? WorkoutId { get; set; }

        public int? Duration { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
