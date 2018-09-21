using learnSpanish.Enums.Error;

namespace learnSpanish.Enums.Service
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

        public static string GetMessageErrorSystem(ErrorSystem errorSystem)
        {
            switch (errorSystem)
            {
                case ErrorSystem.Generic: return "Error system";
                default: return "";
            }
        }
    }
}