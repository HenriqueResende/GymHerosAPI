namespace GymHerosAPI.Model
{
    public class UserDto
    {
        public int? Id { get; set; }

        public string? Token { get; set; }

        public string? Name { get; set; }

        public int? Height { get; set; }

        public double? Weight { get; set; }

        public int? Vitality { get; set; }

        public int? Force { get; set; }

        public int? Defense { get; set; }

        public int? Agility { get; set; }
    }
}
