using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Deal.Commands.Create
{
    public class CreateDealCommand : IRequest<BaseResponse<Guid>>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Guid PipelineId { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public Guid CurrencyId { get; set; }
        public string? Description { get; set; }
        [Required]
        public Guid StageId { get; set; }
        public Guid? ContactId { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        public Guid SourceId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public DateTime ExpectedClosingDate { get; set; }


    }
}
