using Domain.Models;
using Infrastructure.Interfaces;
using Npgsql;
namespace Infrastructure.Services;

public class MovieService : IMovieService
{
    const string connectionstring = "Server = localhost; Port = 5432; Database = Thetres; Username = postgres; Password = js0770";

    public List<Movie> GetAllMovies()
    {
        var movies = new List<Movie>();

        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand("SELECT * FROM movies", connection);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            movies.Add(new Movie
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Director = reader.GetString(2),
                Year = reader.GetInt32(3),
                Duration = reader.GetInt32(4),
                Genre = reader.GetString(5),
                Description = reader.GetString(6)
            });
        }

        return movies;
    }

    public Movie GetMovieById(int id)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand("SELECT * FROM movies WHERE id = @movieId", connection);
        command.Parameters.AddWithValue("@movieId", id);

        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Movie
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Director = reader.GetString(2),
                Year = reader.GetInt32(3),
                Duration = reader.GetInt32(4),
                Genre = reader.GetString(5),
                Description = reader.GetString(6)
            };
        }

        return null!;
    }

    public void AddMovie(Movie movie)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
            @"INSERT INTO movies (title, director, year, duration, genre, description)
            VALUES (@movieTitle, @movieDirector, @movieYear, @movieDuration, @movieGenre, @movieDescription)",
            connection);

        command.Parameters.AddWithValue("@movieTitle", movie.Title);
        command.Parameters.AddWithValue("@movieDirector", movie.Director);
        command.Parameters.AddWithValue("@movieYear", movie.Year);
        command.Parameters.AddWithValue("@movieDuration", movie.Duration);
        command.Parameters.AddWithValue("@movieGenre", movie.Genre);
        command.Parameters.AddWithValue("@movieDescription", movie.Description);

        command.ExecuteNonQuery();
    }

    public void UpdateMovie(Movie movie)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        @"UPDATE movies
        SET title = @movieTitle,
        director = @movieDirector,
        year = @movieYear,
        duration = @movieDuration,
        genre = @movieGenre,
        description = @movieDescription
        WHERE id = @movieId"
        );

        command.Parameters.AddWithValue("@movieId", movie.Id);
        command.Parameters.AddWithValue("@movieTitle", movie.Title);
        command.Parameters.AddWithValue("@movieDirector", movie.Director);
        command.Parameters.AddWithValue("@movieYear", movie.Year);
        command.Parameters.AddWithValue("@movieDuration", movie.Duration);
        command.Parameters.AddWithValue("@movieGenre", movie.Genre);
        command.Parameters.AddWithValue("@movieDescription", movie.Description);

        command.ExecuteNonQuery();
    }

    public void DeleteMovie(int id)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand("DELETE FROM movies WHERE id = @movieId", connection);
        command.Parameters.AddWithValue("@movieId", id);

        command.ExecuteNonQuery();
    }
}