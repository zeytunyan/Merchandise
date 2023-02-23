namespace Merchandise.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException() => Item = "Product";
    }
}
