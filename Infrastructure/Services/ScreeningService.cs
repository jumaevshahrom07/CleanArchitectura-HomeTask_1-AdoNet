using Domain.Models;
using Infrastructure.Services;
using Npgsql;
namespace Infrastructure.Services;

public class ScreeningService : IScreeningService
{
    const string connectionstring = "Server = localhost; Port = 5432; Database = Thetres; Username = postgres; Password = js0770";

    public List<Screening> GetAllScreenings()
    {
        var screenings = new List<Screening>();

        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand("SELECT * FROM screenings", connection);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            screenings.Add(new Screening
            {
                Id = reader.GetInt32(0),
                MovieId = reader.GetInt32(1),
                TheaterId = reader.GetInt32(2),
                ScreeningTime = reader.GetDateTime(3),
                TicketPrice = reader.GetDecimal(4),
                AvailableSeats = reader.GetInt32(5)
            });
        }

        return screenings;
    }

    public Screening GetScreeningById(int id)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        "SELECT * FROM screenings WHERE id = @screeningId"
        );

        command.Parameters.AddWithValue("@screeningId", id);
        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Screening
            {
                Id = reader.GetInt32(0),
                MovieId = reader.GetInt32(1),
                TheaterId = reader.GetInt32(2),
                ScreeningTime = reader.GetDateTime(3),
                TicketPrice = reader.GetDecimal(4),
                AvailableSeats = reader.GetInt32(5)
            };
        }
        return null!;
    }

    public void AddScreening(Screening screening)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        @"INSERT INTO screenings 
        (movie_id, theater_id, screening_time, ticket_price, available_seats)
        VALUES 
        (@movieId, @theaterId, @screeningTime, @ticketPrice, @availableSeats)"
        );

        command.Parameters.AddWithValue("@movieId", screening.MovieId);
        command.Parameters.AddWithValue("@theaterId", screening.TheaterId);
        command.Parameters.AddWithValue("@screeningTime", screening.ScreeningTime);
        command.Parameters.AddWithValue("@ticketPrice", screening.TicketPrice);
        command.Parameters.AddWithValue("@availableSeats", screening.AvailableSeats);

        command.ExecuteNonQuery();
    }

    public void UpdateScreening(Screening screening)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        @"UPDATE screenings
        SET movie_id = @movieId,
        theater_id = @theaterId,
        screening_time = @screeningTime,
        ticket_price = @ticketPrice,
        available_seats = @availableSeats
        WHERE id = @screeningId"
        );

        command.Parameters.AddWithValue("@screeningId", screening.Id);
        command.Parameters.AddWithValue("@movieId", screening.MovieId);
        command.Parameters.AddWithValue("@theaterId", screening.TheaterId);
        command.Parameters.AddWithValue("@screeningTime", screening.ScreeningTime);
        command.Parameters.AddWithValue("@ticketPrice", screening.TicketPrice);
        command.Parameters.AddWithValue("@availableSeats", screening.AvailableSeats);

        command.ExecuteNonQuery();
    }

    public void DeleteScreening(int id)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        "DELETE FROM screenings WHERE id = @screeningId",
        connection);

        command.Parameters.AddWithValue("@screeningId", id);
        command.ExecuteNonQuery();
    }
}
