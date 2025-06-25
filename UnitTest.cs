namespace TestUserAdding
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Validate_ValidClient_DoesNotThrow()
        {
            var client = new Client
            {
                Name = "Иван Иванов",
                DateOfBirth = new DateTime(1990, 1, 1),
                Phone = "+7-123-456-78-90",
                Email = "ivan@example.com"
            };

            Assert.DoesNotThrow(() => client.Validate());
        }

        [Test]
        public void Validate_ClientWithMinNameAndMaxAge_DoesNotThrow()
        {
            var client = new Client
            {
                Name = "А",
                DateOfBirth = new DateTime(1900, 1, 1),
                Phone = "+7-999-888-77-66",
                Email = "a@b.co"
            };

            Assert.DoesNotThrow(() => client.Validate());
        }

        // --- Провальные тесты (будут отмечены как FAILED в Test Explorer) ---

        [Test]
        public void Validate_EmptyName_ThrowsException_ButWeExpectSuccess()
        {
            var client = new Client
            {
                Name = "",
                DateOfBirth = new DateTime(2010, 1, 1),
                Phone = "+7-123-456-78-90",
                Email = "test@example.com"
            };

            // Мы ожидаем успех, но будет брошено исключение → тест провалится
            Assert.DoesNotThrow(() => client.Validate());
        }

        [Test]
        public void Validate_EmailTooLong_ButWeExpectSuccess()
        {
            var longEmail = new string('a', 65) + "@example.com";
            var client = new Client
            {
                Name = "Петр Петров",
                DateOfBirth = new DateTime(1990, 1, 1),
                Phone = "+7-123-456-78-90",
                Email = longEmail
            };

            // Мы ожидаем успех, но будет брошено исключение → тест провалится
            Assert.DoesNotThrow(() => client.Validate());
        }
    }
}
