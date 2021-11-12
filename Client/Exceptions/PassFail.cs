using System;

namespace Client.Exceptions
{
    public class PassFail : Exception
    {
        public PassFail() { }

        public override string Message => "Неправильный пароль";
    }
}
