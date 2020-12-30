using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores player items and money
[CreateAssetMenu(menuName = "PlayerInventory/NewInventory")]
public class PlayerInventory : ScriptableObject
{
    public int Money;


    public List<BaseItem> PlayerItems = new List<BaseItem>();
}
