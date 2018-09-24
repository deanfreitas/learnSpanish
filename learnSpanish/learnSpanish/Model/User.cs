using SQLite;
using SQLiteNetExtensions.Attributes;

namespace learnSpanish.Model
{
    public class User
    {
        public User()
        {
        }

        public User(string name, string email, Login login)
        {
            Name = name;
            Email = email;
            Login = login;
        }

        public User(int id, string name, string email, Login login)
        {
            Id = id;
            Name = name;
            Email = email;
            Login = login;
        }

        [PrimaryKey, AutoIncrement, Column("user_id")]
        public int Id { get; set; }

        [NotNull, Column("user_name")] public string Name { get; set; }

        [NotNull, Column("user_email")] public string Email { get; set; }

        [ForeignKey(typeof(Login)), NotNull, Column("id_login"), Indexed]
        public string LoginId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Login Login { get; set; }
    }
}