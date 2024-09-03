using Hospital.Logic.Models.Enums;
using Hospital.Logic.Models;

namespace Hospital.API.Contracts
{
    public record EditPatientResponse(
        long Id,
        string Surname,
        string Name,
        string? Patronymic,
        string Address,
        DateOnly BirthDate,
        Sex Sex,
        long hospitalSiteId
        );
}
