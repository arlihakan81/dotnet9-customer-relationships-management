using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.ContactStage.Commands.Create
{
    public class CreateContactStageCommand : IRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool Status { get; set; } = true;
    }
}
