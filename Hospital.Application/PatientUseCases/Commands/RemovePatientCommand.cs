namespace Hospital.Application.PatientUseCases.Commands
{
    public sealed record RemovePatientCommand(Patient Patient) : IRequest<Patient>{ }
    

}
