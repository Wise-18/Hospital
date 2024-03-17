namespace Hospital.Domain.Entities
{
    /// <summary>
    /// Пациент
    /// </summary>
    public class Patient : Entity
    {
        /// <summary>
        /// Персональные данные
        /// </summary>
        public Person PersonalData { get; }

        /// <summary>
        /// Температура тела пациента
        /// </summary>
        public double? Temperature { get; private set; }

        /// <summary>
        /// Дата заселения в палату
        /// </summary>
        public DateTime? CheckInDate { get; private set; }

        /// <summary>
        /// Дата выписки из палаты
        /// </summary>
        public DateTime? CheckOutDate { get; private set; }

        /// <summary>
        /// Номер больничной палаты
        /// </summary>
        public int? HospitalWardId { get; private set; }

        private Patient() {}

        public Patient(Person personalData, double? temp = 36.0)
        {
            PersonalData = personalData;
            Temperature = temp;
        }

        /// <summary>
        /// Положить пациента в палату
        /// </summary>
        /// <param name="roomId">Идентификатор палаты</param>
        public void AddToHospitalWard(int roomId)
        {
            if (roomId <= 0) return;

            HospitalWardId = roomId;
            CheckInDate = DateTime.Now;
        }

        /// <summary>
        /// Выписать пациента
        /// </summary>
        public void LeaveCource()
        {
            HospitalWardId = null;
            CheckOutDate = DateTime.Now;
        }

        /// <summary>
        /// Изменить температуру тела пациента
        /// </summary>
        /// <param name="temp"></param>
        public void ChangeRate(double temp)
        {
            if (temp < 36.0 || temp > 42.0) return;
            Temperature = temp;
        }
    }
}
