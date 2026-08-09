using CRM.Application.Dtos.ContactStage;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.ContactStage.Queries.GetContactStage
{
    public class GetContactStageByIdQuery : IRequest<BaseResponse<ContactStageDto>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
