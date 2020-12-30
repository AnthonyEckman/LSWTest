using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages all equipment slot objects
public class EquipScreen : MonoBehaviour
{
    //Reference to UIManager Singleton
    public UIManager myUIManager;
    
    //Reference for all item slots
    //Has to be done manually through inspector
    public EquipSlot Head;
    public EquipSlot Chest;
    public EquipSlot MainHand;
    public EquipSlot OffHand;
    public EquipSlot Waist;
    public EquipSlot Feet;


    // Start is called before the first frame update
    void Start()
    {
        myUIManager = UIManager.Instance;
        myUIManager.EquipScreen = this.gameObject;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Called From Inventory Panel whenever an item is clicked from the inventory screen.
    //Checks the item's category and calls the appropriate item slot to add the item to.
    public void EquipItem(BaseItem item)
    {
        switch (item.myCategory[0])
        {
            case Categories.HeadArmour:
                Head.EquipItem(item);
                break;

            case Categories.ChestArmour:
                Chest.EquipItem(item);
                break;

            case Categories.WaistArmour:
                Waist.EquipItem(item);
                break;

            case Categories.FeetArmour:
                Feet.EquipItem(item);
                break;

            case Categories.MainHand:
                MainHand.EquipItem(item);
                break;

            case Categories.OffHand:
                OffHand.EquipItem(item);
                break;


        }
    }



}
