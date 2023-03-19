using Board.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Core.Service
{
    interface IEmailSender
    {
        void SendEmail(Message messsage);
    }
}
