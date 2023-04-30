using UnityEngine;
using UnityEngine.UI;

namespace JustMobyTest
{
    public abstract class DiscountableView: MonoBehaviour
    {
        [Header("InModel_Discountable")]
        [SerializeField] public float price;
        [SerializeField] public float discount;
        [Header("InView_Discountable")]
        [SerializeField] public Text discountText;
        [SerializeField] public Text discountPrice;
        [SerializeField] public Text withoutDiscountPrice;
        [SerializeField] public GameObject discountObject;

        protected BuyableController _panelController;
        protected PanelModel _panelModel;

    }
}
