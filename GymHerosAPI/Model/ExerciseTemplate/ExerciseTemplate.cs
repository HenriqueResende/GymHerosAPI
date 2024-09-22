namespace GymHerosAPI.Model
{
    public class ExerciseTemplate
    {
        public int? Id { get; set; }

        public int? IdUser { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }

        public int? Vitality { get; set; }

        public int? Strength { get; set; }

        public int? Defense { get; set; }

        public int? Agility { get; set; }
    }
}
