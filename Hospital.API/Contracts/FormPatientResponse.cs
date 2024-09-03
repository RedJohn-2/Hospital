using Hospital.Logic.Models.Enums;

namespace Hospital.API.Contracts
{
    public record FormPatientResponse(
        long Id,
        string Surname,
        string Name,
        string? Patronymic,
        string Address,
        DateOnly BirthDate,
        Sex Sex,
        string hospitalSitenumber
        );
}
