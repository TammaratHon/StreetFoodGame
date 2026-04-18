using System;
using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;

namespace StreetFoodGame.Application.Usecases
{
    public class CustomerOrderUsecase
    {
        private Random random = new Random();
        private readonly IFoodDataRepository foodRepository;
        private readonly ICustomerOrderDataRepository customerOrderDataRepository;

        public CustomerOrderUsecase(
            IFoodDataRepository foodRepository,
            ICustomerOrderDataRepository customerOrderDataRepository
        )
        {
            this.foodRepository = foodRepository;
            this.customerOrderDataRepository = customerOrderDataRepository;
        }

        public Order CreateOrder(string customerKey = "")
        {
            var customerOrderData = string.IsNullOrEmpty(customerKey) ?
                GetRandomCustomerOrderData()
                :
                customerOrderDataRepository.GetCustomerOrderByKey(customerKey);

            var mainFood = customerOrderData.GetRandomMainFood(random);
            var carbFood = customerOrderData.GetRandomCarbFood(random);
            var grilledFood = customerOrderData.GetRandomGrilledFood(random);

            int mainFoodAmount = random.Next(mainFood.amount_min, mainFood.amount_max + 1);
            int carbFoodAmount = random.Next(carbFood.amount_min, carbFood.amount_max + 1);
            int grilledFoodAmount = random.Next(grilledFood.amount_min, grilledFood.amount_max + 1);

            List<FoodData> foodList = new List<FoodData>();
            for (int i = 0; i < mainFoodAmount; i++)
            {
                foodList.Add(foodRepository.GetFoodByKey(mainFood.key));
            }
            for (int i = 0; i < carbFoodAmount; i++)
            {
                foodList.Add(foodRepository.GetFoodByKey(carbFood.key));
            }
            for (int i = 0; i < grilledFoodAmount; i++)
            {
                foodList.Add(foodRepository.GetFoodByKey(grilledFood.key));
            }

            return new Order(new Customer(customerOrderData.key), foodList.ToArray());

        }

        private CustomerOrderData GetRandomCustomerOrderData()
        {
            int customerCount = customerOrderDataRepository.GetAllCustomerOrders().Count;
            var customerData = customerOrderDataRepository.GetAllCustomerOrders()[random.Next(0, customerCount)];
            return customerData;
        }
    }
}