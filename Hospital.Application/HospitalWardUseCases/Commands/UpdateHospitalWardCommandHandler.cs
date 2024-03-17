using Hospital.Application.HospitalWardUseCases.Commands;

namespace Hospital.Application.HospitalWardUseCases.Commands
{
    internal class UpdateHospitalWardCommandHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<UpdateHospitalWardCommand, HospitalWard>
    {
        public async Task<HospitalWard> Handle(UpdateHospitalWardCommand request, CancellationToken cancellationToken)
        {
           var newHospitalWard = request.HospitalWard;

           await unitOfWork.HospitalWardRepository.UpdateAsync(newHospitalWard, cancellationToken);

            return newHospitalWard;
        }
    }
}
