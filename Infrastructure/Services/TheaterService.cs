using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Npgsql;
namespace Infrastructure.Services;

public class TheaterService : ITheaterService
{
    const string connectionstring = "Server = localhost; Port = 5432; Database = Thetres; Username = postgres; Password = js0770";

    public List<Theater> GetAllTheaters()
    {
        var theaters = new List<Theater>();

        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand("SELECT * FROM theaters", connection);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            theaters.Add(new Theater
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Location = reader.GetString(2),
                Manager = reader.GetString(3),
                Phone = reader.GetString(4),
                Capacity = reader.GetInt32(5),
                Website = reader.GetString(6)
            });
        }
        return theaters;
    }

    public Theater GetTheaterById(int id)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        "SELECT * FROM theaters WHERE id = @theaterId",
        connection);

        command.Parameters.AddWithValue("@theaterId", id);

        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Theater
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Location = reader.GetString(2),
                Manager = reader.GetString(3),
                Phone = reader.GetString(4),
                Capacity = reader.GetInt32(5),
                Website = reader.GetString(6)
            };
        }
        return null!;
    }

    public void AddTheater(Theater theater)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        @"INSERT INTO theaters 
        (name, location, manager, phone, capacity, website)
        VALUES 
        (@theaterName, @theaterLocation, @theaterManager, @theaterPhone, @theaterCapacity, @theaterWebsite)"
        );

        command.Parameters.AddWithValue("@theaterName", theater.Name);
        command.Parameters.AddWithValue("@theaterLocation", theater.Location);
        command.Parameters.AddWithValue("@theaterManager", theater.Manager);
        command.Parameters.AddWithValue("@theaterPhone", theater.Phone);
        command.Parameters.AddWithValue("@theaterCapacity", theater.Capacity);
        command.Parameters.AddWithValue("@theaterWebsite", theater.Website);

        command.ExecuteNonQuery();
    }

    public void UpdateTheater(Theater theater)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
            @"UPDATE theaters
            SET name = @theaterName,
            location = @theaterLocation,
            manager = @theaterManager,
            phone = @theaterPhone,
            capacity = @theaterCapacity,
            website = @theaterWebsite
            WHERE id = @theaterId"
        );

        command.Parameters.AddWithValue("@theaterId", theater.Id);
        command.Parameters.AddWithValue("@theaterName", theater.Name);
        command.Parameters.AddWithValue("@theaterLocation", theater.Location);
        command.Parameters.AddWithValue("@theaterManager", theater.Manager);
        command.Parameters.AddWithValue("@theaterPhone", theater.Phone);
        command.Parameters.AddWithValue("@theaterCapacity", theater.Capacity);
        command.Parameters.AddWithValue("@theaterWebsite", theater.Website);

        command.ExecuteNonQuery();
    }

    public void DeleteTheater(int id)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        "DELETE FROM theaters WHERE id = @theaterId");

        command.Parameters.AddWithValue("@theaterId", id);

        command.ExecuteNonQuery();
    }
}
