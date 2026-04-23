using Domain.Models;
namespace Infrastructure.Interfaces;

public interface ITheaterService
{
    List<Theater> GetAllTheaters();
    Theater GetTheaterById(int id);
    void AddTheater(Theater Theater);
    void UpdateTheater(Theater Theater);
    void DeleteTheater(int id);
}
