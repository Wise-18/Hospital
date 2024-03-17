using Hospital.Domain.Entities;

namespace Hospital.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<HospitalWard> HospitalWardRepository { get; }
        IRepository<Patient> PatientRepository { get; }

        Task SaveAllAsync();
        Task DeleteDataBaseAsync();
        Task CreateDataBaseAsync();
    }
}
