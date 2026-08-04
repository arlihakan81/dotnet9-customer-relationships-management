using CRM.Application.Dtos.Lead;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Responses;
using MediatR;

namespace CRM.Application.Features.Lead.Commands.Update
{
    public sealed class UpdateLeadCommandHandler(ILeadRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateLeadCommand>
    {
        private readonly ILeadRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetByIdAsync(request.Id);

            if (lead is null)
                BaseResponse<LeadDto>.FailureResult(lead!.Name, "Requested data is not found");

            else
            {
                lead.Name = request.Name;
                lead.Email = new Domain.ValueObjects.EmailAddress(request.Email);
                lead.Phone = new Domain.ValueObjects.PhoneNumber(request.Phone);
                lead.SourceId = request.SourceId;
                lead.CityId = request.CityId;
                lead.CountryId = request.CountryId;
                lead.Position = request.Position;
                lead.OwnerId = request.OwnerId;

                _repository.UpdateAsync(lead);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
