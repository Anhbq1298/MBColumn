using ColumnDesigner.Application.DTOs;
using ColumnDesigner.Application.Validators;

namespace ColumnDesigner.Application.Services;

public sealed class InputValidationService
{
    private readonly ColumnInputValidator validator = new();

    public ValidationResultDto Validate(ColumnInputDto input) => validator.Validate(input);
}
