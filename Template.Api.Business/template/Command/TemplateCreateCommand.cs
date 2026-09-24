using AutoMapper;
using MediatR;
using Template.Api.Dto;
using Template.Db.UnitOfWork;
using Template.Model;

namespace Template.Api.Business.template.Command
{
    public class TemplateCreateCommand : TemplateInput, IRequest<int> { }
    public class TemplateCreateCommandHandler : IRequestHandler<TemplateCreateCommand, int>
    {
        readonly IMapper _mapper;
        readonly ITemplateApiUnitOfWork _uow;

        public TemplateCreateCommandHandler(
            IMapper mapper,
            ITemplateApiUnitOfWork uow
            )
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(TemplateCreateCommand command, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<TemplateDao>(command);
            await _uow.TemplateRepository.AddAndSaveAsync(data);

            return data.Id;
        }
    }
}