using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerDashboard.Models
{
    public class FitnessEntry
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public float? WeightKg { get; set; }
        public int? Calories { get; set; }

        // FK
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
