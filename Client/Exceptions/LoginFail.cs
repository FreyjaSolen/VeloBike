using System;

namespace Client.Exceptions
{
    public class LoginFail : Exception
    {
        public LoginFail() { }

        public override string Message => "Логин не существует";
    }
}
