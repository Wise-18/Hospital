namespace Hospital.Application.HospitalWardUseCases.Commands
{
    public sealed record UpdateHospitalWardCommand(HospitalWard HospitalWard) : IRequest<HospitalWard>
        { }
}
