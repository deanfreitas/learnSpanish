using SQLite;
using SQLiteNetExtensions.Attributes;

namespace learnSpanish.Model
{
    public class Login
    {
        public Login()
        {
        }

        public Login(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public Login(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        [PrimaryKey, AutoIncrement, Column("login_id")]
        [Indexed(Name = "LoginId", Order = 2, Unique = true)]
        public int Id { get; set; }

        [NotNull, Column("login_user")]
        [Indexed(Name = "LoginId", Order = 1, Unique = true)]
        public string UserName { get; set; }

        [NotNull, Column("login_password")] public string Password { get; set; }
        
        [OneToOne("login_id", "Login")]
        public User User { get; set; }
    }
}