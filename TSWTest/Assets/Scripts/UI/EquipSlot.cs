using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Class for All Equipment Slot

public class EquipSlot : MonoBehaviour,ITextBox
{
    //Reference to EquipmentScreen
    public EquipScreen myEquipmentScreen;

    //ItemReferences
    BaseItem myItem;
    Image myImage;

    // Start is called before the first frame update
    void Start()
    {
        //Grabbing Components
        myImage = GetComponentInChildren<Button>().GetComponent<Image>();
        myImage.color = Color.clear;

        myEquipmentScreen = gameObject.GetComponentInParent<EquipScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Removes Item from reference and puts it back in players inventory and updates inventoryagain
    public void UnEquipItem()
    {
        
        if (myItem != null)
        {
            InventoryManager.Instance.AddToPlayerInventory(myItem);
            UIManager.Instance.UIInventoryMenu.GetComponent<InventoryPanel>().PopulateInventory();
            myImage.sprite = null;
            myItem = null;
            myImage.color = Color.clear;
        }
    }

    //Called From EquipScreen and given item to reference and setup image.
    public void EquipItem(BaseItem item)
    {
        myItem = item;
        myImage.sprite = myItem.icon;
        myImage.color = Color.white;


    }

    //Shows item info when hovered over
    public void SendTextBoxInfo()
    {
        if (myItem != null)
        {
            string text = "Price: " + myItem.price + "\nName: " + myItem.name;
            UIManager.Instance.SpawnTextBox(text);
        }

    }

}
