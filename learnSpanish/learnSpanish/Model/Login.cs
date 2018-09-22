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

        [PrimaryKey, AutoIncrement, Column("login_id")]
        [Indexed]
        public int Id { get; set; }

        [Unique, NotNull, Column("login_user")]
        public string User { get; set; }

        [NotNull, Column("login_password")]
        public string Password { get; set; }
    }
}