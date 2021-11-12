using System;

namespace Client.Exceptions
{
    public class OrderFail : Exception
    {
        public OrderFail() { }

        public override string Message => "Не удалось забронировать велосипед";
    }
}
