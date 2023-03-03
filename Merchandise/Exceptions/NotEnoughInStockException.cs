namespace Merchandise.Exceptions
{
    public class NotEnoughInStockException : IncorrectProductsNumberException
    {
        public override string Message => "Not enough products in stock";
    }
}
