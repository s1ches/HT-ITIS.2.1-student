using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Dto;
using WebApplication1.ErrorMessages;
using WebApplication1.Extensions;

namespace WebApplication1.Services.CachedCalculator;
/// <summary>
/// Калькулятор, который кэширует арифметические выражения и их результаты в MemoryCache
/// а затем, если понадобится результат этого выражения, калькулятор просто достанет его из MemoryCache
/// </summary>
public class MathCachedCalculatorService : IMathCalculatorService
{
	private readonly IMathCalculatorService _simpleCalculator;
	private static readonly MemoryCache CachedExpressions = new (new MemoryCacheOptions());

	public MathCachedCalculatorService(IMathCalculatorService simpleCalculator)
	{
		_simpleCalculator = simpleCalculator;
	}
	
	/// <summary>
	/// Вычисляет значение арифметического выражения, если оно не закэшировано, и кэширует его,
	/// иначе же берёт выражение и его результат из MemoryCache
	/// </summary>
	/// <param name="expression">Арифметическое выражение</param>
	/// <returns>Результат выражения CalculationMathExpressionResultDto</returns>
	public async Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
	{
		if (string.IsNullOrWhiteSpace(expression)) 
			return new CalculationMathExpressionResultDto(MathErrorMessager.EmptyStringMessage());
		
		expression = expression.WithoutSpaces();

		if (CachedExpressions.TryGetValue(expression, out var expressionResult))
			return (expressionResult as CalculationMathExpressionResultDto)!;
		
		var calcResult = await _simpleCalculator.CalculateMathExpressionAsync(expression);

		CachedExpressions.Set(expression, calcResult);

		return calcResult;
	}
}