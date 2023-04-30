using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JustMobyTest
{
    // ќсуществл€ет вывод данных дл€ пользовател€
    public class BuyPanelView : MonoBehaviour
    {
        [SerializeField] public RectTransform transformItems;
        [SerializeField] public Text header;
        [SerializeField] public Text description;
        [SerializeField] public Image mainImage;
        [SerializeField] public GameObject[] itemsGameObject;
        [SerializeField] public Image[] itemsImage;         
        [SerializeField] public Text[] itemsText;
        [SerializeField] public Text discountText;
        [SerializeField] public Text discountPrice;
        [SerializeField] public Text withoutDiscountPrice;
        [SerializeField] public GameObject discountObject;

        public event Action OnButtonClickEvent;
        public event Action StartEvent;

        private void OnEnable()
        {
            StartEvent?.Invoke();
        }
        public void OnButtonClick() => OnButtonClickEvent?.Invoke();
    }
}
