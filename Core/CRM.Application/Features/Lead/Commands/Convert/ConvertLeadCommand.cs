using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRM.Application.Features.Lead.Commands.Convert
{
    public sealed class ConvertLeadCommand : IRequest<BaseResponse<Guid>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required]
        public bool CreateCompany { get; set; } = true;

        [Required]
        public bool CreateContact { get; set; } = true;

        public Guid? ExistingCompanyId { get; set; }

    }
}
