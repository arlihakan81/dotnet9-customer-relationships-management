using CRM.Application.Features.Company.Commands.CreateCompany;
using CRM.Domain.ValueObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CRM.Application.Features.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : CreateCompanyCommand
    {
        [Required]
        public Guid Id { get; set; }
        
    }
}
