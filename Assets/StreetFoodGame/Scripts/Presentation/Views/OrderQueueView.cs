using UnityEngine;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Application.Interfaces;
using System.Collections.Generic;
using TMPro;

namespace StreetFoodGame.Presentation.Views
{
    public class OrderQueueView : MonoBehaviour, IOrderQueueView
    {
        [SerializeField] private OrderSlotView orderSlotPrefab;
        [SerializeField] private Transform orderQueueContainer;

        [SerializeField] private int maxQueueSize = 3;

        private Queue<OrderSlotView> availableSlots = new Queue<OrderSlotView>();

        public void AddOrder(Customer customer, List<Recipe> recipes)
        {
            if (availableSlots.Count < maxQueueSize)
            {
                var slot = Instantiate(orderSlotPrefab, orderQueueContainer);
                slot.gameObject.SetActive(true);
                slot.SetAvatar(customer.Name);
                string[] foodNames = new string[recipes.Count];
                for (int i = 0; i < recipes.Count; i++) {
                    foodNames[i] = recipes[i].Name;
                }
                slot.SetFoodIcons(foodNames);
                availableSlots.Enqueue(slot);
            }
        }

        public void RemoveOrder(Customer customer)
        {
            if (availableSlots.Count > 0)
            {
                var slot = availableSlots.Dequeue();
                Destroy(slot.gameObject);
            }
        }
    }
}