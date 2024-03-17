using Hospital.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Application
{
    public static class DbInitializer
    {

        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
            
            // Создать базу данных заново
            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            var hospitalWard1 = new HospitalWard(1, 10);
            var hospitalWard2 = new HospitalWard(2, 12);

            
            unitOfWork.HospitalWardRepository.AddAsync(hospitalWard1);
            unitOfWork.HospitalWardRepository.AddAsync(hospitalWard2);

            await unitOfWork.SaveAllAsync();

            Random random = Random.Shared;
            double min = 36.6;
            double max = 41.0;

            var patient1 = new Patient(
                    new Person($"Patient 1", DateTime.Now.AddYears(-Random.Shared.Next(30))), min + random.NextDouble() * (max - min));
            patient1.AddToHospitalWard(1);

            var patient2 = new Patient(
                    new Person($"Patient 2", DateTime.Now.AddYears(-Random.Shared.Next(30))), min + random.NextDouble() * (max - min));
            patient2.AddToHospitalWard(1);

            var patient3 = new Patient(
                    new Person($"Patient 3", DateTime.Now.AddYears(-Random.Shared.Next(30))), 36.6);
            patient3.AddToHospitalWard(1);

            var patient4 = new Patient(
                    new Person($"Patient 4", DateTime.Now.AddYears(-Random.Shared.Next(30))), min + random.NextDouble() * (max - min));
            patient4.AddToHospitalWard(1);

            var patient5 = new Patient(
                    new Person($"Patient 5", DateTime.Now.AddYears(-Random.Shared.Next(30))), min + random.NextDouble() * (max - min));
            patient5.AddToHospitalWard(2);

            var patient6 = new Patient(
                    new Person($"Patient 6", DateTime.Now.AddYears(-Random.Shared.Next(30))), min + random.NextDouble() * (max - min));
            patient6.AddToHospitalWard(1);

            unitOfWork.PatientRepository.AddAsync(patient1);
            unitOfWork.PatientRepository.AddAsync(patient2);
            unitOfWork.PatientRepository.AddAsync(patient3);
            unitOfWork.PatientRepository.AddAsync(patient4);
            unitOfWork.PatientRepository.AddAsync(patient5);
            unitOfWork.PatientRepository.AddAsync(patient6);

            await unitOfWork.SaveAllAsync();
        }
    }
}
