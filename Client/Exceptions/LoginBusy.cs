using System;

namespace Client.Exceptions
{
    public class LoginBusy : Exception
    {
        public LoginBusy() { }

        public override string Message => "Такой логин уже занят";
    }
}