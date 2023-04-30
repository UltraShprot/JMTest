using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace JustMobyTest
{
    // Хранит в себе данные о модели и корректирует эти данные при изменении
    public class BuyPanelModel
    {
        public string HeaderText { get; set; }
        public string DescriptionText { get; set; }
        public string MainImageName { get; set; }
        public float ActualPrice { get; set; }
        private List<(string,int)> itemsNameAndCount = new List<(string,int)>();
        public List<(string, int)> ItemsNameAndCount 
        {   get => itemsNameAndCount;
            set 
            {
                if (value.Count >= 3 && value.Count <= 6) itemsNameAndCount = value; 
                else if (value.Count > 6)
                {
                    Debug.Log("Максимум должно быть 6 предметов! Список ограничен.");
                    for (int i = 0; i < value.ToArray().Length; i++) 
                    {
                        itemsNameAndCount.Add(value[i]);
                    }
                }
                else if (value.Count > 0)
                {
                    Debug.Log("Минимум должно быть три предмета! Список дополнен последним предметом.");
                    for (int i = 0; i < 3; i++)
                    {
                        try { itemsNameAndCount.Add(value[i]); }
                        catch { itemsNameAndCount.Add(value[value.Count - 1]); }

                    }
                }
                else 
                {
                    Debug.LogError("Предметы не добавлены!");
                }
            }
        }
     
        private float price;
        public float Price 
        {   get => price;
            set 
            {
                if (value >= 0) 
                {
                    Math.Round(value, 2);
                    price = value; 
                }
                else
                { 
                    price = 0; 
                }
            }
        }


        private float discount;
        public float Discount 
        {   get => discount;
            set
            {
                Math.Round(value, 2);
                if (value >= 0 && value <= 100) discount = value;
                else if (value > 100) discount = 100;
                else discount = 0;
            }
        }

        public BuyPanelModel(string headerText, List<(string, int)> itemsNameAndCount, string descriptionText, float price, float discount, string mainImageName)
        {
            HeaderText = headerText;
            DescriptionText = descriptionText;
            ItemsNameAndCount= itemsNameAndCount;
            Price = price;
            Discount = discount;
            MainImageName = mainImageName;
        }

    }
}
