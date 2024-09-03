namespace Hospital.API.Contracts
{
    public record EditDoctorResponse(
        long Id,
        string FullName,
        long OfficeId,
        long SpecializationId,
        long? HospitalSiteId
        );
}
