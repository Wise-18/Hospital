namespace Hospital.Application.HospitalWardUseCases.Commands
{
    public sealed record AddHospitalWardCommand(int RoomNumber, int RoomСapacity) : IRequest<HospitalWard>
        { }
}
