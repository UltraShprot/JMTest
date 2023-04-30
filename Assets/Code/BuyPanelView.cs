using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JustMobyTest
{
    public class BuyPanelView : DiscountableView
    {
        [Header("InModel")]
        [SerializeField] public string headerText;
        [SerializeField] public string descriptionText; 
        [SerializeField] public List<(string, int)> itemNameAndCount; 
        [SerializeField] public string mainImageName;
        [SerializeField] public RectTransform transformItems;

        [Header("InView")]
        [SerializeField] public Text header;
        [SerializeField] public Text description;
        [SerializeField] public Image mainImage;
        [SerializeField] public GameObject[] itemsGameObject;
        [SerializeField] public Image[] itemsImage;         
        [SerializeField] public Text[] itemsText;             

        public event Action OnButtonClickEvent;
        public event Action StartEvent;

        private void OnEnable()
        {
            _panelModel = new BuyPanelModel(headerText, itemNameAndCount, descriptionText, price, discount, mainImageName, transformItems);
            _panelController = new BuyPanelController(this, (BuyPanelModel)_panelModel);
            StartEvent?.Invoke();
        }
        public void OnButtonClick() => OnButtonClickEvent?.Invoke();
    }
}
