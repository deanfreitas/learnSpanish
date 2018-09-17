using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using learnSpanish.model;

namespace learnSpanish.utils
{
    public class LoginUtils
    {
        public static string CheckLogin(Login login)
        {
            StringBuilder message = new StringBuilder("You need send your: ");
            bool isValidLogin = true;

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