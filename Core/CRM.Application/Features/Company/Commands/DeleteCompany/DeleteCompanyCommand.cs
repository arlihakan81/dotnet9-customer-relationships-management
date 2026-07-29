using MediatR;

namespace CRM.Application.Features.Company.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
