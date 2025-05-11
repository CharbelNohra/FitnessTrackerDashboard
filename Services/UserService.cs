using BCrypt.Net;
using FitnessTrackerDashboard.Data;
using FitnessTrackerDashboard.Models;

namespace FitnessTrackerDashboard.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public User? Authenticate(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.HashedPassword))
                return user;

            return null;
        }

        public void Register(string username, string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User { Username = username, HashedPassword = hashedPassword };
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}