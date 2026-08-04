using AutoMapper;
using CRM.Application.Dtos.Contact;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Contact.Queries.GetContact
{
    public class GetContactByIdQueryHandler(IContactRepository repository, IMapper mapper) : IRequestHandler<GetContactByIdQuery, BaseResponse<ContactDto>>
    {
        private 
            readonly IContactRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<ContactDto>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await  _repository.GetByIdAsync(request.Id);
            if (contact == null)
            {
                return BaseResponse<ContactDto>.FailureResult("Contact not found", "Contact not found");
            }
            var contactDto = _mapper.Map<ContactDto>(contact);
            return BaseResponse<ContactDto>.SuccessResult(contactDto, "Contact retrieved successfully");
        }
    }
}
