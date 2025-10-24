namespace ProductManagement.Exceptions;

public class ProductNotFoundException : BaseException
{
    protected ProductNotFoundException(Guid productId) : base($"Product with ID {productId} was not found", 404, "PRODUCT_NOT_FOUND")
    {
    }
}