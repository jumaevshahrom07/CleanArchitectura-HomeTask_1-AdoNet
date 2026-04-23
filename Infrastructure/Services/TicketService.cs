using Domain.Models;
using Infrastructure.Interfaces;
using Npgsql;

namespace Infrastructure.Services;

public class TicketService : ITicketService
{
    const string connectionstring = "Server = localhost; Port = 5432; Database = Thetres; Username = postgres; Password = js0770";

    public List<Ticket> GetAllTickets()
    {
        var tickets = new List<Ticket>();

        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand("SELECT * FROM tickets", connection);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            tickets.Add(new Ticket
            {
                Id = reader.GetInt32(0),
                ScreeningId = reader.GetInt32(1),
                CustomerName = reader.GetString(2),
                SeatNumber = reader.GetString(3),
                PurchaseTime = reader.GetDateTime(4),
                Price = reader.GetDecimal(5),
                PaymentMethod = reader.GetString(6)
            });
        }

        return tickets;
    }

    public Ticket GetTicketById(int id)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        "SELECT * FROM tickets WHERE id = @ticketId");

        command.Parameters.AddWithValue("@ticketId", id);

        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Ticket
            {
                Id = reader.GetInt32(0),
                ScreeningId = reader.GetInt32(1),
                CustomerName = reader.GetString(2),
                SeatNumber = reader.GetString(3),
                PurchaseTime = reader.GetDateTime(4),
                Price = reader.GetDecimal(5),
                PaymentMethod = reader.GetString(6)
            };
        }
        return null!;
    }

    public void AddTicket(Ticket ticket)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        @"INSERT INTO tickets 
        (screening_id, customer_name, seat_number, purchase_time, price, payment_method)
        VALUES 
        (@screeningId, @customerName, @seatNumber, @purchaseTime, @price, @paymentMethod)");

        command.Parameters.AddWithValue("@screeningId", ticket.ScreeningId);
        command.Parameters.AddWithValue("@customerName", ticket.CustomerName);
        command.Parameters.AddWithValue("@seatNumber", ticket.SeatNumber);
        command.Parameters.AddWithValue("@purchaseTime", ticket.PurchaseTime);
        command.Parameters.AddWithValue("@price", ticket.Price);
        command.Parameters.AddWithValue("@paymentMethod", ticket.PaymentMethod);

        command.ExecuteNonQuery();
    }

    public void UpdateTicket(Ticket ticket)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        @"UPDATE tickets
        SET screening_id = @screeningId,
        customer_name = @customerName,
        seat_number = @seatNumber,
        purchase_time = @purchaseTime,
        price = @price,
        payment_method = @paymentMethod
        WHERE id = @ticketId");

        command.Parameters.AddWithValue("@ticketId", ticket.Id);
        command.Parameters.AddWithValue("@screeningId", ticket.ScreeningId);
        command.Parameters.AddWithValue("@customerName", ticket.CustomerName);
        command.Parameters.AddWithValue("@seatNumber", ticket.SeatNumber);
        command.Parameters.AddWithValue("@purchaseTime", ticket.PurchaseTime);
        command.Parameters.AddWithValue("@price", ticket.Price);
        command.Parameters.AddWithValue("@paymentMethod", ticket.PaymentMethod);
        command.ExecuteNonQuery();
    }

    public void DeleteTicket(int id)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var command = new NpgsqlCommand(
        "DELETE FROM tickets WHERE id = @ticketId");

        command.Parameters.AddWithValue("@ticketId", id);
        command.ExecuteNonQuery();
    }

    public void BuyTicket(int screeningId, string customerName, string seatNumber, decimal price, string paymentMethod)
    {
        using var connection = new NpgsqlConnection(connectionstring);
        connection.Open();

        var checkcommand = new NpgsqlCommand(
        "SELECT available_seats FROM screenings WHERE id = @screeningId");

        checkcommand.Parameters.AddWithValue("@screeningId", screeningId);

        var result = checkcommand.ExecuteScalar();

        if (result == null)
        {
            Console.WriteLine("Screening failed not found");
            return;
        }

        int availableSeats = Convert.ToInt32(result);

        if (availableSeats <= 0)
        {
            Console.WriteLine("No available seats");
            return;
        }

        var insertcommand = new NpgsqlCommand(
        @"INSERT INTO tickets 
        (screening_id, customer_name, seat_number, purchase_time, price, payment_method)
        VALUES 
        (@screeningId, @customerName, @seatNumber, @purchaseTime, @price, @paymentMethod)");

        insertcommand.Parameters.AddWithValue("@screeningId", screeningId);
        insertcommand.Parameters.AddWithValue("@customerName", customerName);
        insertcommand.Parameters.AddWithValue("@seatNumber", seatNumber);
        insertcommand.Parameters.AddWithValue("@purchaseTime", DateTime.Now);
        insertcommand.Parameters.AddWithValue("@price", price);
        insertcommand.Parameters.AddWithValue("@paymentMethod", paymentMethod);

        insertcommand.ExecuteNonQuery();

        var updateCommand = new NpgsqlCommand(
        "UPDATE screenings SET available_seats = available_seats - 1 WHERE id = @screeningId");
        updateCommand.Parameters.AddWithValue("@screeningId", screeningId);

        updateCommand.ExecuteNonQuery();
        Console.WriteLine("Ticket founded successfully!");
    }
}