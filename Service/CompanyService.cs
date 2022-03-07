using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared;

namespace Service;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
    {
        try
        {
            return _mapper.Map<IEnumerable<CompanyDto>>(_repository.Company.GetAllCompanies(trackChanges));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong it the {nameof(GetAllCompanies)} service method {ex}");
            throw;
        }
    }
}