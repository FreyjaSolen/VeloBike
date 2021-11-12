using System;

namespace Client.Exceptions
{
    public class DeleteFail : Exception
    {
        public DeleteFail() { }

        public override string Message => "Ошибка удаления из базы данных";
    }
}