using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IconInfo", menuName = "Icon/New IconInfo")]
public class IconInfo : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name => _name;
    [SerializeField] private Sprite _icon;
    public Sprite Icon => _icon;
}
