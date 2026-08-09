using CRM.Application.Features.ContactStage.Commands.Create;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.ContactStage.Commands.Update
{
    public class UpdateContactStageCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool Status { get; set; }
    }
}
