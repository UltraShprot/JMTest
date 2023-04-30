using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace JustMobyTest
{
    public class Master : MonoBehaviour
    {
        [SerializeField] private InputField _inputField;

        [SerializeField] private BuyPanelView _view;
        private BuyPanelController _controller;
        private BuyPanelModel _model;

        List<(string, int)> items = new List<(string, int)>()
        {
            ("Heart", 20),
            ("Slime", 60),
            ("Bullets", 30),
            ("Heart", 20),
            ("Slime", 60),
            ("Heart", 20),
            ("Slime", 60),
            ("Bullets", 30)
        };
        List<(string, int)> itemsNew = new List<(string, int)>();



        public void PanelActive()
        {
            int itemsCount = Convert.ToInt32(_inputField.text);
            if (itemsCount > 0)
            {
                for (int i = 0; i < itemsCount; i++)
                {
                    try { itemsNew.Add(items[i]); }
                    catch { itemsNew.Add(items[items.Count - 1]); }
                }
            }
            _model = new BuyPanelModel("Название", itemsNew, "Описание", 15.99f, 15, "Monster");
            _controller= new BuyPanelController(_view, _model);
            _view.gameObject.SetActive(true);

        } 
        
    }
}
