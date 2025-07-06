namespace Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        private User() { }

        private User(string name, string email)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required");

            Name = name;
            Email = email;
        }

        public static User Create(string name, string email) => new User(name, email);

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty");
            Name = newName;
        }

        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                throw new ArgumentException("Email cannot be empty");
            Email = newEmail;
        }
    }
}