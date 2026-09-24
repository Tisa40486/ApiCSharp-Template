using AutoMapper;
using Template.Api.Dto;
using Template.Model;

namespace Inoks.Api.Hardware.Business
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<TemplateDao, TemplateReponse>();
            CreateMap<TemplateInput, TemplateDao>();
        }
    }
}