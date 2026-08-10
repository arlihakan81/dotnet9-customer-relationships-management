using AutoMapper;
using CRM.Application.Dtos.Deal;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Deal.Queries.GetDeal
{
    public class GetDealByIdQueryHandler(IDealRepository repository, IMapper mapper) : IRequestHandler<GetDealByIdQuery, BaseResponse<DealDto>>
    {
        private readonly IDealRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<DealDto>> Handle(GetDealByIdQuery request, CancellationToken cancellationToken)
        {
            var deal = await _repository.GetByIdAsync(request.Id);

            if (deal == null)
            {
                return BaseResponse<DealDto>.FailureResult("No deal found", $"No deal found by deal Id {request.Id}");
            }

            var data = _mapper.Map<DealDto>(deal);

            return BaseResponse<DealDto>.SuccessResult(data, "Retrieved requested data successfully");

        }
    }
}
