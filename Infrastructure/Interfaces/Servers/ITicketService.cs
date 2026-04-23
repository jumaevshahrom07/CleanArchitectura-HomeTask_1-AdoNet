using Domain.Models;
namespace Infrastructure.Interfaces;

public interface ITicketService
{
    List<Ticket> GetAllTickets();
    Ticket GetTicketById(int id);
    void AddTicket(Ticket Ticket);
    void UpdateTicket(Ticket Ticket);
    void DeleteTicket(int id);
}
