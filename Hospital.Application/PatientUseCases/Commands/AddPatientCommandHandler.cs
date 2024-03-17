namespace Hospital.Application.PatientUseCases.Commands
{
    internal class AddPatientCommandHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<AddPatientCommand, Patient>
    {
        public async Task<Patient> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            Patient newPatient = new Patient(new Person(
             request.Name,
             request.DateOfBirth), request.Temperatura);
            if (request.GroupId.HasValue)
            {
                newPatient.AddToHospitalWard(request.GroupId.Value);
            }

            await unitOfWork.PatientRepository.AddAsync(
                newPatient,
                cancellationToken);

            return newPatient;
        }
    }
    }
