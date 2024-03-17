using Hospital.Application.PatientUseCases.Commands;

namespace Hospital.Application.HospitalWardUseCases.Commands
{

    internal class AddHospitalWardCommandHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<AddHospitalWardCommand, HospitalWard>
    {
        public async Task<HospitalWard> Handle(AddHospitalWardCommand request, CancellationToken cancellationToken)
        {
            HospitalWard hospitalWard = new HospitalWard(request.RoomNumber, request.RoomСapacity);

            await unitOfWork.HospitalWardRepository.AddAsync(
                hospitalWard,
                cancellationToken);

            return hospitalWard;
        }
    }
}
