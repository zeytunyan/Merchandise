namespace Merchandise.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException() => Item = "Order";
    }
}
