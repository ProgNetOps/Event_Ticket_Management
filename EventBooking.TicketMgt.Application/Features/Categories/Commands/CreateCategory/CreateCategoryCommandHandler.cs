using EventBooking.TicketMgt.Application.Contracts.Persistence;

namespace EventBooking.TicketMgt.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper): 
    IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository=categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        CreateCategoryCommandResponse createCategoryCommandResponse = new();
        
        CreateCategoryCommandValidator validator = new();
        var validationResult=await validator.ValidateAsync(request);

        if (validationResult.Errors.Count>0)
        {
            createCategoryCommandResponse.Success = false;
            createCategoryCommandResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }
        if (createCategoryCommandResponse.Success)
        {
            Category category = new() { Name=request.Name };
            category = await _categoryRepository.AddAsync(category);
            createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
        }

        //Returns a custom type that contains both data and possible validation errors to the caller
        return createCategoryCommandResponse;
    }
}
