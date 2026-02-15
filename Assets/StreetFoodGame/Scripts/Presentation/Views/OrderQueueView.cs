using UnityEngine;

public class OrderQueueView : MonoBehaviour, IOrderQueueView
{
    public void AddOrder(Customer customer)
    {
        // Here you would typically update the UI to show the new order in the queue.
    }

    public void RemoveOrder(Customer customer)
    {
        // Here you would typically update the UI to remove the order from the queue.
    }
}