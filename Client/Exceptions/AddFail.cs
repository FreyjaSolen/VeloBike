using System;

namespace Client.Exceptions
{
    public class AddFail : Exception
    {
        public AddFail() { }

        public override string Message => "Ошибка добавления в базу данных";
    }
}
