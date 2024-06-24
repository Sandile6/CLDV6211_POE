namespace KhumaloTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public string UserName { get; internal set; }
        public string Role { get; internal set; }
    }
}