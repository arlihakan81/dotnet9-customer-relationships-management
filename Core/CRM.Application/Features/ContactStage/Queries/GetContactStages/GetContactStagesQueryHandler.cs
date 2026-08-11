using AutoMapper;
using CRM.Application.Dtos.ContactStage;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.ContactStage.Queries.GetContactStages
{
    public class GetContactStagesQueryHandler(IContactStageRepository repository, IMapper mapper) : IRequestHandler<GetContactStagesQuery, BaseResponse<PagedList<ContactStageDto>>>
    {
        private readonly IContactStageRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<PagedList<ContactStageDto>>> Handle(GetContactStagesQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAllAsync(request.Page, request.PageSize);

            if (request.Filter is not null)
                query = query!.Where(_ => _.Name.Contains(request.Filter));

            var data = _mapper.Map<IEnumerable<ContactStageDto>>(query);
            var items = new PagedList<ContactStageDto>(data, request.Page, request.PageSize);

            return BaseResponse<PagedList<ContactStageDto>>.SuccessResult(items, 200, "Retrieved all contact stages successfully");
        }
    }
}
