namespace WebApplication1.ErrorMessages;

public static class MathErrorMessager
{
    private const string DivisionByZero = "Division by zero";
    private const string EmptyString =  "Empty string";
    private const string IncorrectBracketsNumber = "The number of closing and opening brackets does not match";
    private const string StartingWithOperation =  "An expression cannot start with an operation sign";
    private const string EndingWithOperation =  "An expression cannot end with an operation sign";
    private const string NotNumber =  "There is no such number";
    private const string UnknownCharacter =  "Unknown character";
    private const string TwoOperationInRow = "There are two operations in a row";
    private const string InvalidOperatorAfterParenthesis = "After the opening brackets, only negation can go";
    private const string OperationBeforeParenthesis = "There is only a number before the closing parenthesis";

    public static string DivisionByZeroMessage() => DivisionByZero;
    
    public static string EmptyStringMessage () => EmptyString;
        
    public static string IncorrectBracketsNumberMessage() => IncorrectBracketsNumber;
    
    public static string StartingWithOperationMessage () => StartingWithOperation;
    
    public static string EndingWithOperationMessage () => EndingWithOperation;
    
    public static string NotNumberMessage(string num) =>
        $"{NotNumber} {num}";
    
    public static string UnknownCharacterMessage(char symbol) =>
        $"{UnknownCharacter} {symbol}";

    public static string TwoOperationInRowMessage(string firstOperation, string secondOperation) =>
        $"{TwoOperationInRow} {firstOperation} and {secondOperation}";

    public static string InvalidOperatorAfterParenthesisMessage(string operation) =>
        $"{InvalidOperatorAfterParenthesis} ({operation}";

    public static string OperationBeforeParenthesisMessage(string operation) =>
        $"{OperationBeforeParenthesis} {operation})";
}