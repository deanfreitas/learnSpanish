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

        [NotNull, Column("user_name")]
        public string Name { get; set; }

        [NotNull, Column("user_email")]
        [Indexed(Name = "UserId", Order = 2, Unique = true)]
        public string Email { get; set; }

        [ForeignKey(typeof(Login)), NotNull, Column("login_id")]
        [Indexed(Name = "UserId", Order = 1, Unique = true)]
        public int LoginId { get; set; }

        [OneToOne("login_id", "User", CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public Login Login { get; set; }
    }
}