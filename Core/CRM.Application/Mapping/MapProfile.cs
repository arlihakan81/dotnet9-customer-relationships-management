using AutoMapper;
using CRM.Application.Dtos.Company;
using CRM.Application.Features.Company.Commands.CreateCompany;
using CRM.Domain.Entities;

namespace CRM.Application.Mapping
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<Company, CompanyDto>();
        }


    }
}
