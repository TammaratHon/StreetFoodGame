using System.Collections.Generic;
using UnityEngine;
using VContainer;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Domain.Enums;

namespace StreetFoodGame.Presentation.Views
{
    public class OrderQueueView : MonoBehaviour, IOrderQueueView
    {
        [SerializeField] private OrderSlotView orderSlotPrefab;
        [SerializeField] private Transform orderQueueContainer;

        [SerializeField] private int maxQueueSize = 3;

        private Queue<OrderSlotView> availableSlots = new Queue<OrderSlotView>();
        private ISpriteProviderService spriteProvider;

        [Inject]
        public void Construct(ISpriteProviderService spriteProvider)
        {
            this.spriteProvider = spriteProvider;
        }

        public void AddOrder(Customer customer, string sentence)
        {
            if (availableSlots.Count < maxQueueSize)
            {
                var slot = Instantiate(orderSlotPrefab, orderQueueContainer);
                slot.gameObject.SetActive(true);
                
                slot.SetCustomerSentence(sentence);
                slot.SetCustomerImage(GetCustomerSprite(customer.Key, customer.Mood));
                slot.SetCustomerMoodImage(GetCustomerMoodSprite(customer.Mood));
                slot.SetCustomerFlavorText("");
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

        public Sprite GetCustomerSprite(string customerKey, CustomerMood mood)
        {
            string moodSuffix = mood switch
            {
                CustomerMood.Happy => "Green",
                CustomerMood.Neutral => "Yellow",
                CustomerMood.Impatient => "Orange",
                CustomerMood.Angry => "Red",
                _ => ""
            };

            customerKey = char.ToUpper(customerKey[0]) + customerKey.Substring(1);

            return (Sprite)spriteProvider.LoadSpriteInSheet(
                "Graphics2D/SpriteSheets/Customer_Spritesheet",
                customerKey + "_" + moodSuffix
            );
        }

        public Sprite GetCustomerMoodSprite(CustomerMood mood)
        {
            string moodSuffix = mood switch
            {
                CustomerMood.Happy => "Green",
                CustomerMood.Neutral => "Yellow",
                CustomerMood.Impatient => "Orange",
                CustomerMood.Angry => "Red",
                _ => ""
            };

            return (Sprite)spriteProvider.LoadSpriteInSheet(
                "Graphics2D/SpriteSheets/Customer_Spritesheet",
                "Background" + moodSuffix
            );
        }
    }
}