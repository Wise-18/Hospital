namespace Hospital.Application.PatientUseCases.Commands
{
    public sealed record UpdatePatientCommand(Patient Patient) : IRequest<Patient>
        { }
}
