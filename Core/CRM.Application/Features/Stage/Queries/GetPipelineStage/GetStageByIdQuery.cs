using CRM.Application.Dtos.Stage;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Stage.Queries.GetPipelineStage
{
    public class GetStageByIdQuery : IRequest<BaseResponse<StageDto>>
    {
        [Required]
        public Guid Id { get; set; }


    }
}
