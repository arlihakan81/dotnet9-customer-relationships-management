using AutoMapper;
using CRM.Application.Dtos.ContactStage;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.ContactStage.Queries.GetContactStage
{
    public sealed class GetContactStageByIdQueryHandler(IContactStageRepository repository, IMapper mapper) : IRequestHandler<GetContactStageByIdQuery, BaseResponse<ContactStageDto>>
    {
        private readonly IContactStageRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<ContactStageDto>> Handle(GetContactStageByIdQuery request, CancellationToken cancellationToken)
        {
            var stage = await _repository.GetByIdAsync(request.Id);
            if (stage == null)
            {
                return BaseResponse<ContactStageDto>.FailureResult("No found contact stage", $"No found contact stage by request Id: {request.Id}");
            }
            var data = _mapper.Map<ContactStageDto>(stage);
            return BaseResponse<ContactStageDto>.SuccessResult(data, "Retrieved contact stage by Id ");
        }
    }
}
