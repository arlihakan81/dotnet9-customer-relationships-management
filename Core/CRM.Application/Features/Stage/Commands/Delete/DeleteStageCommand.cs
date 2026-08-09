using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Stage.Commands.Delete
{
    public class DeleteStageCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
