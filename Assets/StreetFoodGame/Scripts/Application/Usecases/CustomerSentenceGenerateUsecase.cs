using System.Text;
using System.Linq;
using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;
using System;
using StreetFoodGame.Domain.Interfaces;

namespace StreetFoodGame.Application.Usecases
{
    public class CustomerSentenceGenerateUsecase
    {
        private readonly Random random = new Random();
        private readonly ICustomerOrderDataRepository customerOrderDataRepository;

        public CustomerSentenceGenerateUsecase(ICustomerOrderDataRepository customerOrderDataRepository)
        {
            this.customerOrderDataRepository = customerOrderDataRepository;
        }

        public string GenerateSentence(Customer customer, List<FoodData> foods)
        {
            Dictionary<string, int> foodDict = new();
                
            for (int i = 0; i < foods.Count; i++) {
                string foodName = foods[i].name;
                if (foodDict.ContainsKey(foodName)) {
                    foodDict[foodName]++;
                } else {
                    foodDict[foodName] = 1;
                }
            }

            StringBuilder sentencesBuilder = new StringBuilder();
            string beginningText = GetRandomSentence(customerOrderDataRepository.GetCustomerOrderByKey(customer.Key).beginning_sentence);

            List<string> middleTexts = new();
            int middleTextCount = foodDict.Count - 1;
            for (int i = 0; i < middleTextCount; i++) {
                middleTexts.Add(GetRandomSentence(customerOrderDataRepository.GetCustomerOrderByKey(customer.Key).middle_sentence));
            }

            string endText = GetRandomSentence(customerOrderDataRepository.GetCustomerOrderByKey(customer.Key).end_sentence);

            sentencesBuilder.Append(beginningText);
            sentencesBuilder.Replace("(Menu)", $"<color=#E53888>{foodDict.ElementAt(0).Key} {foodDict.ElementAt(0).Value}</color>");
                
            for (int i = 0; i < middleTextCount; i++)
            {
                string middleText = middleTexts[i];
                sentencesBuilder.Append(" ");
                middleText = middleText.Replace("(Menu)", $"<color=#E53888>{foodDict.ElementAt(i + 1).Key} {foodDict.ElementAt(i + 1).Value}</color>");
                sentencesBuilder.Append(middleText);
            }

            sentencesBuilder.Append(" ");
            sentencesBuilder.Append(endText);

            return sentencesBuilder.ToString();
        }

        private string GetRandomSentence(string[] sentences)
        {
            return sentences[random.Next(0, sentences.Length)];
        }
    }
}