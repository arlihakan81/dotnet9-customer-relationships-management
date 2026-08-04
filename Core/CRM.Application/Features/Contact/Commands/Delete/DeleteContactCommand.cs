using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Contact.Commands.Delete
{
    public sealed class DeleteContactCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
