using CRM.Application.Dtos.Deal;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Deal.Queries.GetDeal
{
    public class GetDealByIdQuery : IRequest<BaseResponse<DealDto>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
