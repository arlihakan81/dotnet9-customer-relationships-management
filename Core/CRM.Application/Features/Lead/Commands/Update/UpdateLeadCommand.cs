using CRM.Application.Features.Lead.Commands.Create;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Lead.Commands.Update
{
    public class UpdateLeadCommand : CreateLeadCommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
