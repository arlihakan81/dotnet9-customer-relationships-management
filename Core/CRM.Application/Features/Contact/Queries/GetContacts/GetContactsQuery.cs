using CRM.Application.Dtos.Contact;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Contact.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<BaseResponse<PagedList<ContactDto>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string? Filter { get; set; }
        public Guid? CompanyId { get; set; }

    }
}
