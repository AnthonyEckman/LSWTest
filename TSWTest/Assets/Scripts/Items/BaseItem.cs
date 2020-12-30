using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains all the categories of items in the game
public enum Categories
{
    FoodItem,
    HeadArmour,
    ChestArmour,
    WaistArmour,
    FeetArmour,
    MainHand,
    OffHand
}



//Container for each item in game
[System.Serializable]
[CreateAssetMenu(menuName = "ItemGenerator/newItem")]
public abstract class BaseItem : ScriptableObject
{
    public string myName;
    public Sprite icon = null;
    public string description = "description";
    public int price = 0;

    //Determins what categories each item belongs to by looking ad the Categories enumerator
    //can be edited in inspector
    public List<Categories> myCategory = new List<Categories>();

}
