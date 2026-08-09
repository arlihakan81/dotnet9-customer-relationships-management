using CRM.Application.Features.Stage.Commands.Create;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Stage.Commands.Update
{
    public class UpdateStageCommand : CreateStageCommand
    {
        [Required]
        public Guid Id { get; set; }

    }
}
