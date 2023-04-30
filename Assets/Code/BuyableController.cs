using System.Collections.Generic;
using UnityEngine;

namespace JustMobyTest
{
    public abstract class BuyableController
    {
        protected List<(string, int)> buyingItems = new List<(string, int)>();

        public abstract void Buy();
    }
}
