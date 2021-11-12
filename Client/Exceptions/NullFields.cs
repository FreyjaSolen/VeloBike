using System;

namespace Client.Exceptions
{
    public class NullFields : Exception
    {
        public NullFields() { }

        public override string Message => "Заполните все обязательные поля";
    }
}
