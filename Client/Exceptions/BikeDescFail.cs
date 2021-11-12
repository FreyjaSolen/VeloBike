using System;

namespace Client.Exceptions
{
    public class BikeDescFail : Exception
    {
        public BikeDescFail() { }

        public override string Message => "Описание должно быть не менее 20 символов";
    }
}
