using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MessageService.DTO;
using MessageService.Services.Interfaces;
using MessageService.Storage.Interfaces;
using MessageService.Storage.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [Route("api/messages")]
    [EnableCors("AllowAllMethods")]
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
        public async Task<string> Send([FromBody] Message message)
        {
            var isSendToAllRecipienrs = _notificationService.TryNotifyRecepients(message.RecipientIds, message.Body);

            // In real app it is better to use mapper instead of this part
            var dbMessage = new DbMessage
            {
                IsSent = isSendToAllRecipienrs,
                Body = message.Body,
                MessageRecipients = message.RecipientIds.Select(x => new DbMessageRecipient { RecipientId = x}).ToList(),
                Subject = message.Subject
            };
            
            await _storageService.Add(dbMessage);

            return dbMessage.Id;
        }
    }
}