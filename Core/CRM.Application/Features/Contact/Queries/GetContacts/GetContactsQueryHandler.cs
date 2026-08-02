using AutoMapper;
using CRM.Application.Dtos.Contact;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Contact.Queries.GetContacts
{
    public class GetContactsQueryHandler(IContactRepository repository, IMapper mapper) : IRequestHandler<GetContactsQuery, BaseResponse<PagedList<ContactDto>>>
    {
        private readonly IContactRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<PagedList<ContactDto>>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAllAsync(request.Page, request.PageSize);
            if (!string.IsNullOrEmpty(request.Filter))
            {
                query = query!.Where(c => c.FirstName.Contains(request.Filter) || c.LastName.Contains(request.Filter));
            }
            var items = _mapper.Map<List<ContactDto>>(query);
            var pagedList = new PagedList<ContactDto>(items, request.Page, request.PageSize);
            return BaseResponse<PagedList<ContactDto>>.SuccessResult(pagedList);
        }
    }
}
