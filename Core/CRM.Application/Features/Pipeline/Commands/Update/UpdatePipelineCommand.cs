using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Pipeline.Commands.Update
{
    public class UpdatePipelineCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;


    }
}
