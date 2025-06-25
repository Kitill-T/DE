using System.Text.RegularExpressions;

namespace TestUserAdding
{
    public class Client
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("ФИО не может быть пустым");

            if (Name.Length > 31)
                throw new ArgumentException("ФИО не должно превышать 31 символ");

            var age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now < DateOfBirth.AddYears(age)) age--;

            if (age < 18)
                throw new ArgumentException("Клиент должен быть старше 18 лет");

            if (!Phone.StartsWith("+7") || Phone.Length != 16 ||
                !Regex.IsMatch(Phone, @"^\+7-\d{3}-\d{3}-\d{2}-\d{2}$"))
                throw new ArgumentException("Номер должен начинаться с +7 и соответствовать формату: +7-XXX-XXX-XX-XX");

            if (Email.Length > 64)
                throw new ArgumentException("Email не должен превышать 64 символа");

            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email имеет неверный формат");
        }
    }
}
