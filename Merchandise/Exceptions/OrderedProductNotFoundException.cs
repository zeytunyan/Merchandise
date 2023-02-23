namespace Merchandise.Exceptions
{
    public class OrderedProductNotFoundException : NotFoundException
    {
        public override string Message => "The specified order does not contain the specified product";
    }
}
