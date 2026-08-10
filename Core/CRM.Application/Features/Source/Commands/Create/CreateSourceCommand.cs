using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Source.Commands.Create
{
    public class CreateSourceCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public bool Status { get; set; } = true;
    }
}
