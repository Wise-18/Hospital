namespace Hospital.Application.PatientUseCases.Queries
{
    public sealed record GetPatientsByHospitalWardRequest(int Id) : IRequest<IEnumerable<Patient>> {    }
}
