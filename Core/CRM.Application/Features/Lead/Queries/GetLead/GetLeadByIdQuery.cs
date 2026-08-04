using CRM.Application.Dtos.Lead;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Lead.Queries.GetLead
{
    public class GetLeadByIdQuery : IRequest<BaseResponse<LeadDto>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
