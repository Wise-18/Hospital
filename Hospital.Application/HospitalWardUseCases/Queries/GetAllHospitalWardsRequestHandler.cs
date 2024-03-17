namespace Hospital.Application.HospitalWardUseCases.Queries
{
    public class GetAllHospitalWardsRequestHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<GetAllHospitalWardsRequest, IEnumerable<HospitalWard>>
    {

        public async Task<IEnumerable<HospitalWard>> Handle(
            GetAllHospitalWardsRequest request,
            CancellationToken cancellationToken)
        {
            return await unitOfWork.HospitalWardRepository
            .ListAllAsync(cancellationToken);
        }
    }

}
