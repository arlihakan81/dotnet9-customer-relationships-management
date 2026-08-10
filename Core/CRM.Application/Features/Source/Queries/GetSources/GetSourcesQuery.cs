using CRM.Application.Dtos.Source;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Source.Queries.GetSources
{
    public class GetSourcesQuery : IRequest<BaseResponse<PagedList<SourceDto>>>
    {
        [Required]
        public int Page { get; set; } = 1;
        [Required]
        public int Count { get; set; } = 100;

        public string? Filter { get; set; }



    }
}
