using learnSpanish.enums.error;

namespace learnSpanish.enums.service
{
    public class EnumsService
    {
        public static string GetMessageErrorUser(ErrorUser errorUser)
        {
            switch (errorUser)
            {
                case ErrorUser.WrongCredentials: return "Your user or password is wrong";
                default: return "";
            }
        }
    }
}