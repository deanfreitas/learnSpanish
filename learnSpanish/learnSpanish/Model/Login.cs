using SQLite;

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

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, NotNull]
        public string User { get; set; }

        [NotNull]
        public string Password { get; set; }
    }
}