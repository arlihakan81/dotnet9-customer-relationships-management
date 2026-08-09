using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.ContactStage.Commands.Delete
{
    public class DeleteContactStageCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
