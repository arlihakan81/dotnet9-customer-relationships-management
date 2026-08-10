using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Deal.Commands.Delete
{
    public class DeleteDealCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
