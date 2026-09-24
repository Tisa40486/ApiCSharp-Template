using AutoMapper;
using MediatR;
using Template.Api.Dto;
using Template.Db.UnitOfWork;

namespace Template.Api.Business.template.Query
{
    public class TemplateGetQuery : IRequest<IEnumerable<TemplateReponse>>
    {
    }
    public class TemplateGetQueryHandler : IRequestHandler<TemplateGetQuery, IEnumerable<TemplateReponse>>
    {
        readonly IMapper _mapper;
        readonly ITemplateApiUnitOfWork _uow;

        public TemplateGetQueryHandler(
            IMapper mapper,
            ITemplateApiUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<TemplateReponse>> Handle(TemplateGetQuery request, CancellationToken cancellation)
        {
            var data = await _uow.TemplateRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TemplateReponse>>(data);
        }
    }
}