using EMessenger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMessenger.DataBaseContext.Interfaces
{
    /// <summary>
    /// Инткерфейс репозитория для работы с сообщениями.
    /// </summary>
    public interface IMessageRepository : IRepository<Message>
    {

    }
}
