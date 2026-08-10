using CRM.Application.Features.Deal.Commands.Create;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Deal.Commands.Update
{
    public class UpdateDealCommand : CreateDealCommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
