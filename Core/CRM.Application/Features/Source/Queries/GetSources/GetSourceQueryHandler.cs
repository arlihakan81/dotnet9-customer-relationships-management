using AutoMapper;
using CRM.Application.Dtos.Source;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Source.Queries.GetSources
{
    public class GetSourceQueryHandler(ISourceRepository repository, IMapper mapper) : IRequestHandler<GetSourcesQuery, BaseResponse<PagedList<SourceDto>>>
    {
        private readonly ISourceRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<PagedList<SourceDto>>> Handle(GetSourcesQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAllAsync(request.Page, request.Count);

            if (!string.IsNullOrEmpty(request.Filter))
                query = query!.Where(_ => _.Name.Contains(request.Filter));

            var data = _mapper.Map<IEnumerable<SourceDto>>(query);
            var items = new PagedList<SourceDto>(data, request.Page, request.Count);

            return BaseResponse<PagedList<SourceDto>>.SuccessResult(items, "Retrieved all sources succeed");
        }
    }
}
