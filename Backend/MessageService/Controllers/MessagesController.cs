using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MessageService.DataBase.Interfaces;
using MessageService.DataBase.Models;
using MessageService.DTO;
using MessageService.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [Route("api/messages")]
    public class MessagesController : Controller
    {
        private readonly IStorageService _storageService;

        private readonly INotificationService _notificationService;

        public MessagesController(IStorageService storageService, INotificationService notificationService)
        {
            _storageService = storageService;
            _notificationService = notificationService;
        }

        [HttpPost("send")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Send([FromBody] Message message)
        {
            var isSendToAllRecipienrs = _notificationService.TryNotifyRecepients(message.RecipientIds, message.Body);

            // In real app it is better to use mapper instead of this part
            var dbMessage = new DbMessage
            {
                IsSent = isSendToAllRecipienrs,
                Body = message.Body,
                Recipients = message.RecipientIds.Select(x => new DbRecipient { Id = x }).ToList(),
                Subject = message.Subject
            };
            
            await _storageService.Add(dbMessage);

            return Ok(dbMessage.Id);
        }
    }
}