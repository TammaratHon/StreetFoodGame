using UnityEngine;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Application.Interfaces;
using System.Collections.Generic;
using TMPro;
using System.Text;
using VContainer;
using StreetFoodGame.Domain.Enums;
using System.Linq;

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

        public void AddOrder(Customer customer, List<Recipe> recipes)
        {
            if (availableSlots.Count < maxQueueSize)
            {
                var slot = Instantiate(orderSlotPrefab, orderQueueContainer);
                slot.gameObject.SetActive(true);
                // string[] foodNames = new string[recipes.Count];
                Dictionary<string, int> foods = new();
                
                for (int i = 0; i < recipes.Count; i++) {
                    string foodName = recipes[i].Name;
                    if (foods.ContainsKey(foodName)) {
                        foods[foodName]++;
                    } else {
                        foods[foodName] = 1;
                    }
                }

                StringBuilder sentencesBuilder = new StringBuilder();
                string beginningText = customer.BeginSentences[Random.Range(0, customer.BeginSentences.Length)];

                List<string> middleTexts = new();
                int middleTextCount = foods.Count - 1;
                for (int i = 0; i < middleTextCount; i++) {
                    middleTexts.Add(customer.MiddleSentences[Random.Range(0, customer.MiddleSentences.Length)]);
                }

                string endText = customer.EndSentences[Random.Range(0, customer.EndSentences.Length)];

                sentencesBuilder.Append(beginningText);
                sentencesBuilder.Append(" ");
                sentencesBuilder.Append($"<color=#E53888>{foods.ElementAt(0).Key} {foods.ElementAt(0).Value}</color>");
                
                for (int i = 0; i < middleTextCount; i++)
                {
                    string middleText = middleTexts[i];
                    middleText = middleText.Replace("-", $"<color=#E53888>{foods.ElementAt(i + 1).Key} {foods.ElementAt(i + 1).Value}</color>");
                    sentencesBuilder.Append(middleText);
                }

                sentencesBuilder.Append(" ");
                sentencesBuilder.Append(endText);
                
                slot.SetCustomerOrderText(sentencesBuilder.ToString());
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