using AutoMapper;
using CRM.Application.Dtos.Company;
using CRM.Application.Dtos.Contact;
using CRM.Application.Dtos.Lead;
using CRM.Application.Features.Company.Commands.CreateCompany;
using CRM.Domain.Entities;

namespace CRM.Application.Mapping
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<Company, CompanyDto>().ForMember(des => des.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(des => des.Country, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(des => des.Phone, op => op.MapFrom(src => src.Country.PhoneCode+src.Phone.Value))
                .ForMember(des => des.AlternatePhone, opt => opt.MapFrom(src => src.Country.PhoneCode+src.AlternatePhone!.Value))
                .ForMember(des => des.Fax, opt => opt.MapFrom(src => src.Country.PhoneCode+src.Fax!.Value));

            CreateMap<Contact, ContactDto>().ForMember(des => des.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(des => des.Country, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(des => des.Mobile, opt => opt.MapFrom(src => src.Country.PhoneCode+ src.Mobile.Value))
                .ForMember(des => des.Phone, opt => opt.MapFrom(src => src.Phone != null ?  src.Country.PhoneCode+src.Phone.Value : null))
                .ForMember(des => des.Company, opt => opt.MapFrom(src => src.Company.Name));

            CreateMap<Lead, LeadDto>()
                .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(des => des.Phone, opt => opt.MapFrom(src => src.Country.PhoneCode + src.Phone.Value));

        }


    }
}
