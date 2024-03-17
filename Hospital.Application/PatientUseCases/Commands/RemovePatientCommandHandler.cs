namespace Hospital.Application.PatientUseCases.Commands
{
    internal class RemovePatientHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<RemovePatientCommand, Patient>
    {
        public async Task<Patient> Handle(RemovePatientCommand request, CancellationToken cancellationToken)
        {
            var entite = request.Patient;

            await unitOfWork.PatientRepository.DeleteAsync(
                entite,
                cancellationToken);

            return entite;
        }
    }
}
