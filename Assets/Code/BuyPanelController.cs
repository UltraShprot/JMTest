using JetBrains.Annotations;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace JustMobyTest
{
    public class BuyPanelController : BuyableController
    {
        private BuyPanelView view;
        private BuyPanelModel model;

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
            float newPrice = new DiscountSetter().SetDiscount(model.Price, model.Discount, view);
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
                view.itemsGameObject[i].GetComponent<RectTransform>().localPosition = new Vector2(model.TransformItems.anchoredPosition.x + x, model.TransformItems.anchoredPosition.y - y);

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
        public override void Buy()
        {
            // Тут логика покупки
            // if (bank.balance >= model.ActualPrice) 
            //    bank.balance -= model.ActualPrice;
            //    foreach (buyingItem in buyingItems) { inventory.list.Add(buyingItem); }      

            Debug.Log("Купили.");
        }
    }
}
