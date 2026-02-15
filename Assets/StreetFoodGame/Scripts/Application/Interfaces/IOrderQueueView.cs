public interface IOrderQueueView
{
    /// <summary>
    /// Update the order queue display with the given list of recipe names.
    /// </summary>
    void AddOrder(Customer customer);

    /// <summary>
    /// Remove an order from the queue by its recipe name. This is typically called when an order is completed.
    /// </summary>
    void RemoveOrder(Customer customer);
}