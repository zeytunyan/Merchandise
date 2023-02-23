namespace Merchandise.Exceptions
{
    public class NotFoundException : Exception
    {
        public string? Item { get; set; }

        public NotFoundException(string item = "Data")
        {
            Item = item;
        }

        public override string Message => $"{Item} not found";
    }
}
