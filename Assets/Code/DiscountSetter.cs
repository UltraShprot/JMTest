using System;

namespace JustMobyTest
{
    public class DiscountSetter
    {
        public float SetDiscount(float price, float discount, DiscountableView view)
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

    }
}
