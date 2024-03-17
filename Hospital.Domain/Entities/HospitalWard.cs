namespace Hospital.Domain.Entities
{
    /// <summary>
    /// Больничная палата
    /// </summary>
    public class HospitalWard : Entity
    {
        /// <summary>
        /// Список пациентов
        /// </summary>
        private List<Patient> _patients = new();

        private HospitalWard() {}

        public HospitalWard(int roomNumber, int roomCapacity)
        {
            RoomNumber = roomNumber;
            RoomСapacity = roomCapacity;
        }

        /// <summary>
        /// Номер палаты
        /// </summary>
        public int RoomNumber { get; set; }

        /// <summary>
        /// Вместительность палаты
        /// </summary>
        public int RoomСapacity { get; set; }

        /// <summary>
        /// Количество пациентов в палате
        /// </summary>
        public int Count => Patients.Count;

        /// <summary>
        /// Публичное свойство для доступа к списку паицентов
        ///  (только для чтения)
        /// </summary>
        public IReadOnlyList<Patient> Patients => _patients.AsReadOnly();
    }
}
