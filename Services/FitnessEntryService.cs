using FitnessTrackerDashboard.Models;
using MySqlConnector;

public class FitnessEntryService
{
    private readonly string _connectionString;

    public FitnessEntryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public List<FitnessEntry> GetEntriesByUserId(int userId)
    {
        var entries = new List<FitnessEntry>();
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string query = "SELECT * FROM fitnessentries WHERE UserId = @userId";
        using var cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@userId", userId);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            entries.Add(new FitnessEntry
            {
                Id = reader.GetInt32("Id"),
                Date = reader.GetDateTime("Date"),
                WeightKg = reader.GetFloat("WeightKg"),
                Calories = reader.GetInt32("Calories"),
                UserId = reader.GetInt32("UserId")
            });
        }
        return entries;
    }

    public void AddEntry(FitnessEntry entry)
    {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string query = "INSERT INTO fitnessentries (Date, WeightKg, Calories, UserId) VALUES (@date, @weight, @calories, @userId)";
        using var cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@date", entry.Date);
        cmd.Parameters.AddWithValue("@weight", entry.WeightKg);
        cmd.Parameters.AddWithValue("@calories", entry.Calories);
        cmd.Parameters.AddWithValue("@userId", entry.UserId);
        cmd.ExecuteNonQuery();
    }

    public bool HasEntryThisWeek(int userId)
    {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string query = "SELECT COUNT(*) FROM fitnessentries WHERE UserId = @userId AND WEEK(Date) = WEEK(NOW())";
        using var cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@userId", userId);
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }
}
