using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerDashboard.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        public ICollection<FitnessEntry> FitnessEntries { get; set; }
    }
}
