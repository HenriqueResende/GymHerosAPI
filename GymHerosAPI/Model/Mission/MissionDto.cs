namespace GymHerosAPI.Model
{
    public class MissionDto
    {
        public int? Id { get; set; }

        public string? Type { get; set; }

        public string? TargetType { get; set; }

        public int? Target { get; set; }

        public int? Reward { get; set; }

        public bool? Done { get; set; }
    }
}
