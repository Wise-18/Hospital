namespace Hospital.Application.PatientUseCases.Commands
{
    public sealed record AddPatientCommand(
    string Name, DateTime DateOfBirth, double? Temperatura, int? GroupId) : IRequest<Patient>{ }
    

}
