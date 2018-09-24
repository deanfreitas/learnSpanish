using System.Text;
using learnSpanish.Model;

namespace learnSpanish.utils
{
    public class UserUtils
    {
        public static string CheckLogin(Login login)
        {
            var message = new StringBuilder("You need send your: ");
            var isValidLogin = true;

            if (string.IsNullOrEmpty(login.User))
            {
                message.AppendLine("User");
                isValidLogin = false;
            }

            if (string.IsNullOrEmpty(login.Password))
            {
                message.AppendLine("Password");
                isValidLogin = false;
            }

            return !isValidLogin ? message.ToString() : null;
        }

        public static string CheckUser(User user)
        {
            var message = new StringBuilder("You need send your: ");
            var isValidUser = true;

            if (string.IsNullOrEmpty(user.Name))
            {
                message.AppendLine("Name");
                isValidUser = false;
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                message.AppendLine("Email");
                isValidUser = false;
            }
            
            if (string.IsNullOrEmpty(user.Login.User))
            {
                message.AppendLine("User");
                isValidUser = false;
            }

            if (string.IsNullOrEmpty(user.Login.Password))
            {
                message.AppendLine("Password");
                isValidUser = false;
            }

            return !isValidUser ? message.ToString() : null;
        }
    }
}