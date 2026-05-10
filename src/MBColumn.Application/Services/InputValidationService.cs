using MBColumn.Application.DTOs;
using MBColumn.Application.Validators;

namespace MBColumn.Application.Services;

public sealed class InputValidationService
{
    private readonly ColumnInputValidator validator = new();

    public ValidationResultDto Validate(ColumnInputDto input) => validator.Validate(input);
}

