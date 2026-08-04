using CRM.Application.Dtos.Contact;
using CRM.Application.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.Contact.Queries.GetContact
{
    public class GetContactByIdQuery : IRequest<BaseResponse<ContactDto>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
