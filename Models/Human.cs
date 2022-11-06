namespace HumanAPI.Models
{
    /// <summary>
    /// Human Object.
    /// </summary
    public class Human
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
