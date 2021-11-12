using System;

namespace Client.Exceptions
{
    public class NickClaim : Exception
    {
        public NickClaim() { }

        public override string Message => "Логин: от 3 до 20 символов без пробелов";
    }
}
