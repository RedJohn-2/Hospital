namespace Hospital.API.Contracts
{
    public record FormDoctorResponse(
        long Id,
        string FullName,
        string OfficeNumber,
        string SpecializationName,
        string? HospitalSiteNumber
        );
}
