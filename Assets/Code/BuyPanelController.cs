using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace JustMobyTest
{
    // Здесь происходит основная логика панели покупки
    public class BuyPanelController
    {
        private BuyPanelView view;
        private BuyPanelModel model;

        protected List<(string, int)> buyingItems = new List<(string, int)>();

        public BuyPanelController(BuyPanelView view, BuyPanelModel model)
        {
            this.view = view;
            this.model = model;
            view.StartEvent += Start;
            view.OnButtonClickEvent += Buy;
        }
        private void Start()
        {
            view.header.text = model.HeaderText;
            view.description.text = model.DescriptionText;
            view.mainImage.sprite = FindIcon(model.MainImageName);
            float newPrice = SetDiscount(model.Price, model.Discount, view);
            if (newPrice != 0)
            {
                model.ActualPrice= newPrice;
                view.discountPrice.text = "$" + newPrice.ToString("0.00");
            }
            else
            {
                view.discountPrice.text = "FREE";
            }
            AddItems();
            
        }
        private void AddItems()
        {
            int x = 0;
            int y = 0;
            int minCount = 0;
            if (model.ItemsNameAndCount.Count > view.itemsGameObject.Length) minCount = view.itemsGameObject.Length;
            else minCount = model.ItemsNameAndCount.Count;
            for (int i = 0; i < minCount; i++) 
            {
                view.itemsGameObject[i].SetActive(true);
                view.itemsGameObject[i].GetComponent<RectTransform>().localPosition = new Vector2(view.transformItems.anchoredPosition.x + x, view.transformItems.anchoredPosition.y - y);

                view.itemsImage[i].sprite = FindIcon(model.ItemsNameAndCount[i].Item1);

                view.itemsText[i].text = model.ItemsNameAndCount[i].Item2.ToString();
                buyingItems.Add((model.ItemsNameAndCount[i]));

                x += 100;
                if ((i + 1) % 3 == 0 && i != 0) 
                {
                    y += 70;
                    if (model.ItemsNameAndCount.Count - i > 3)
                    {
                        x = 0;
                    }
                    else if (model.ItemsNameAndCount.Count - i > 2)
                    {
                        x = 50;
                    }
                    else
                    {
                        x = 100;
                    }
                }
            }
            
        }
        private float SetDiscount(float price, float discount, BuyPanelView view)
        {
            if (price != 0)
            {
                if (discount != 0 && discount != 100)
                {
                    view.discountText.text = "-" + discount.ToString() + "%";
                    view.withoutDiscountPrice.text = "$" + price.ToString();
                    price = price / 100 * (100 - discount);
                    price = (float)Math.Round(price, 2);
                    return price;
                }
                else if (discount == 100)
                {
                    view.discountText.text = "-" + discount.ToString() + "%";
                    view.withoutDiscountPrice.text = "$" + price.ToString();
                    return 0;
                }
                else
                {
                    view.withoutDiscountPrice.text = "";
                    view.discountObject.SetActive(false);
                    return price;
                }
            }
            else
            {
                view.withoutDiscountPrice.text = "";
                view.discountObject.SetActive(false);
                return price;
            }
        }
        private Sprite FindIcon(string nameIcon)
        {
            var icons = Resources.LoadAll<IconInfo>("Info");
            foreach (var icon in icons)
            {
                if (icon.Name == nameIcon)
                {
                    return icon.Icon;
                }
            }
            return null;
        }
        private void Buy()
        {
            // Тут логика покупки
            // if (bank.balance >= model.ActualPrice) 
            //    bank.balance -= model.ActualPrice;
            //    foreach (buyingItem in buyingItems) { inventory.list.Add(buyingItem); }      

            Debug.Log("Купили.");
        }
    }
}
