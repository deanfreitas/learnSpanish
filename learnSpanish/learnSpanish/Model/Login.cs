namespace learnSpanish.Model
{
    public class Login
    {
        public Login()
        {
        }

        public Login(string user, string password)
        {
            User = user;
            Password = password;
        }

        public Login(int id, string user, string password)
        {
            Id = id;
            User = user;
            Password = password;
        }

        public int Id { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
    }
}