using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MessageService.DTO
{
    public class Message
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Subject should be no more than 100 characters.")]
        public string Subject { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Body should be no more than 255 characters.")]
        public string Body { get; set; }

        [Required]
        public List<string> RecipientIds { get; set; }
    }
}
