namespace Merchandise.Exceptions
{
    public class ProductPresentInOrderException : Exception
    {
        public override string Message => $"The product is present in the order";
    }
}
