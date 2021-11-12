using System;

namespace Client.Exceptions
{
    public class PassClaim : Exception
    {
        public PassClaim() { }

        public override string Message => "Пароль: от 6 до 30 символов без пробелов";
    }
}
