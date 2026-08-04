using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Lead.Commands.Convert
{
    public sealed class ConvertLeadToCompanyCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
