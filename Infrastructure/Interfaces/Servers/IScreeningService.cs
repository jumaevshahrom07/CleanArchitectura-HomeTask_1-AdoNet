using Domain.Models;
namespace Infrastructure;

public interface IScreeningService
{
    List<Screening> GetAllScreenings();
    Screening GetScreeningById(int id);
    void AddScreening(Screening Screening);
    void UpdateScreening(Screening Screening);
    void DeleteScreening(int id);
}
