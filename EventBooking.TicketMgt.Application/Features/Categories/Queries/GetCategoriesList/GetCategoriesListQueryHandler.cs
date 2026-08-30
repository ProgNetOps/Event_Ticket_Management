using AutoMapper;
using EventBooking.TicketMgt.Application.Contracts.Persistence;

namespace EventBooking.TicketMgt.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper)
    : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var allCategories = (await _categoryRepository.ListAllAsync()).
            OrderBy(x => x.Name);

        return _mapper.Map<List<CategoryListVm>>(allCategories);
    }
}
