namespace Hospital.Application.PatientUseCases.Queries
{
    public class GetPatientsByHospitalWardRequestHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<GetPatientsByHospitalWardRequest, IEnumerable<Patient>>
    {

        public async Task<IEnumerable<Patient>> Handle(
        GetPatientsByHospitalWardRequest request,
        CancellationToken cancellationToken)
        {
            return await unitOfWork.PatientRepository
            .ListAsync(t => t.HospitalWardId == request.Id,
            cancellationToken);
        }
    }

}
