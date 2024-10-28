using FluentValidation;
using MediatR;
using MiniShop.Application.Common.Exceptions;

namespace MiniShop.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any()) return await next();
        
        var validatorContext = new ValidationContext<TRequest>(request);

        var errors = validators.Select(x => x.Validate(validatorContext))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(x => x.ErrorMessage)
            .Distinct()
            .ToArray();

        if (errors.Any())
        {
            throw new BadRequestInputDataException(errors);
        }

        return await next();
    }
}