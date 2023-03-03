namespace Merchandise.Exceptions
{
    public class NotOnSaleException : Exception
    {
        public override string Message => "Product is not on sale";
    }
}
