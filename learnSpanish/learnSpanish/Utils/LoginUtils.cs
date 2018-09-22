using System.Text;
using learnSpanish.Model;

namespace learnSpanish.utils
{
    public class LoginUtils
    {
        public static string CheckLogin(Login login)
        {
            var message = new StringBuilder("You need send your: ");
            var isValidLogin = true;

            if (string.IsNullOrEmpty(login.User))
            {
                message.AppendLine("user");
                isValidLogin = false;
            }

            if (string.IsNullOrEmpty(login.Password))
            {
                message.AppendLine("password");
                isValidLogin = false;
            }

            return !isValidLogin ? message.ToString() : null;
        }
    }
}