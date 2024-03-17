using Hospital.Application.PatientUseCases.Commands;

namespace Hospital.Application.HospitalWardUseCases.Commands
{
    internal class UpdatePatientCommandHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<UpdatePatientCommand, Patient>
    {
        public async Task<Patient> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var newPatient = request.Patient;

           await unitOfWork.PatientRepository.UpdateAsync(newPatient, cancellationToken);

            return newPatient;
        }
    }
}
