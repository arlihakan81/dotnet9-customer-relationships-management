using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Pipeline.Commands.Delete
{
    public class DeletePipelineCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
