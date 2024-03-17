using Hospital.Domain.Abstractions;
using Hospital.Domain.Entities;
using Hospital.Persistence.Data;

namespace Hospital.Persistence.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Patient>> _patiientRepository;
        private readonly Lazy<IRepository<HospitalWard>> _hospitalWardRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _patiientRepository = new Lazy<IRepository<Patient>>(() =>  new EfRepository<Patient>(context));
            _hospitalWardRepository = new Lazy<IRepository<HospitalWard>>(() => new EfRepository<HospitalWard>(context));
        }

        public IRepository<HospitalWard> HospitalWardRepository => _hospitalWardRepository.Value;

        public IRepository<Patient> PatientRepository => _patiientRepository.Value;

        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() =>  await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() =>  await _context.SaveChangesAsync();
    }
}
