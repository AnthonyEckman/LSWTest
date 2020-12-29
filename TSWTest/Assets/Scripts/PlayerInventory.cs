using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerInventory/NewInventory")]
public class PlayerInventory : ScriptableObject
{
    public int Money;


    public List<BaseItem> PlayerItems = new List<BaseItem>();
}
