namespace Merchandise.Exceptions
{
    public class IncorrectProductsNumberException : Exception
    {
        public override string Message => $"Incorrect products number";
    }
}
